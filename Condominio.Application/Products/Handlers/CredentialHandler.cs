﻿using AutoMapper;
using Condominio.Core.Helpers;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Condominio.Application.Products.Commands.Credential;
using Condominio.Application.Interfaces.Services;
using System;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Core.Extensions;
using Condominio.Application.Models.Credential;
using System.Linq;

namespace Condominio.Application.Products.Handlers
{
    public class CredentialHandler :
        IRequestHandler<CreateCredentialCommand, Result<Guid>>,
        IRequestHandler<CreateTokenCommand, Result<CredentialTokenResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly ICredentialRepository _credentialRepository;
        private readonly INotificationService _notificationService;

        public CredentialHandler(
            IMapper mapper,
            IAuthService authService,
            ICredentialRepository credentialRepository,
            INotificationService notificationService
        )
        {
            this._mapper = mapper;
            this._authService = authService;
            this._credentialRepository = credentialRepository;
            this._notificationService = notificationService;
        }

        public async Task<Result<Guid>> Handle(CreateCredentialCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Credential>(request);

            var passwords = _authService.EncryptPassword(request.Password);

            entity.SetPasswords(passwords.PasswordHash, passwords.PasswordSalt);

            await _credentialRepository.CreateCredential(entity);

            _notificationService.SendEmail(entity.Email);

            return entity.Id.ValidateResultCreate();
        }

        public async Task<Result<CredentialTokenResponse>> Handle(CreateTokenCommand request, CancellationToken cancellationToken)
        {
            Credential entity = await this._credentialRepository.Authenticate(request.Email);
            CredentialTokenResponse credentialTokenResponse = null;

            if (entity is null)
                return credentialTokenResponse.ValidateResultAuthentication();

            var hashedPassword = _authService.CreateHash(request.Password, entity.PasswordSalt);

            if (!_authService.HashedPasswordsEquals(hashedPassword, entity.PasswordHash))
                return credentialTokenResponse.ValidateResultAuthentication();

            var token = _authService.GenerateToken(entity.Id.ToString(), entity.Email, entity.ApplicationUsers.FirstOrDefault().ApplicationUserTypeCode.ToString());
            credentialTokenResponse = new CredentialTokenResponse() { Token = token };

            return credentialTokenResponse.ValidateResultAuthentication();
        }
    }
}