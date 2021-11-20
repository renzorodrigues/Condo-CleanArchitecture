using AutoMapper;
using Condominio.Core.Helpers;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Condominio.Application.Models;
using Condominio.Application.Products.Commands.Account;
using Condominio.Application.Interfaces.Services;
using System;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Core.Extensions;

namespace Condominio.Application.Products.Handlers
{
    public class AccountHandler : 
        IRequestHandler<CreateAccountCommand, Result<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IAuthService _authService;
        private readonly ICredentialRepository _credentialRepository;
        private readonly IApplicationUserRepository _applicationUserRepository;
        private readonly INotificationService _notificationService;

        public AccountHandler(
            IMapper mapper,
            IAuthService authService,
            ICredentialRepository credentialRepository,
            IApplicationUserRepository applicationUserRepository,
            INotificationService notificationService
        )
        {
            this._mapper = mapper;
            this._authService = authService;
            this._credentialRepository = credentialRepository;
            this._applicationUserRepository = applicationUserRepository;
            this._notificationService = notificationService;
        }

        public async Task<Result<Guid>> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
        {       
            var entity = _mapper.Map<Credential>(request);

            entity.ApplicationUserId = entity.ApplicationUser.GetGuid();
            entity.ApplicationUser.SetEmail(request.Email);
            await _applicationUserRepository.CreateApplicationUser(entity.ApplicationUser);

            var passwords = _authService.EncryptPassword(request.Password);

            entity.SetPasswords(passwords.PasswordHash, passwords.PasswordSalt);

            await _credentialRepository.CreateCredential(entity);

            _notificationService.SendSMS("+5534991346615");
            //_notificationService.SendEmail(entity.ApplicationUser.Email, entity.Username);

            return entity.ApplicationUserId.ValidateResultCreate();
        }
    }
}
