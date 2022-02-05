using AutoMapper;
using Condominio.Core.Helpers;
using Condominio.Domain.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Condominio.Application.Products.Commands.Account;
using Condominio.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;
using Condominio.Core.Extensions;
using Condominio.Application.Interfaces.Services;
using Condominio.Application.Models.Account;

namespace Condominio.Application.Products.Handlers
{
    public class AccountHandler : 
        IRequestHandler<AccountRegisterCommand, Result<IdentityResult>>,
        IRequestHandler<AccountLoginCommand, Result<AccountResponse>>
    {

        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly SignInManager<AppUser> _signInManager;

        public AccountHandler(IAccountRepository accountRepository, IMapper mapper, ITokenService tokenService, SignInManager<AppUser> signInManager)
        {
            this._accountRepository = accountRepository;
            this._mapper = mapper;
            this._tokenService = tokenService;
            this._signInManager = signInManager;
        }

        public async Task<Result<IdentityResult>> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AppUser>(request);

            entity.UserNameToLower();

            var result = await _accountRepository.Register(entity, request.Password);

            if (!result.Succeeded)
                return result.ValidateResultBadRequest();

            await _accountRepository.AddUserRole(entity, "member");

            return result.ValidateResultCreated();
        }

        public async Task<Result<AccountResponse>> Handle(AccountLoginCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<AppUser>(request);

            entity.UserNameToLower();

            var user = await _accountRepository.Login(entity);

            if (user is null)
                return new AccountResponse().AuthenticationFailed();

            var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

            if (!checkPassword.Succeeded)
                return new AccountResponse().AuthenticationFailed();

            var role = await _accountRepository.GetRole(user);
            
            if (role is null)
                return new AccountResponse().ValidateResultBadRequest("Role não identificado para o usuário");

            var token = await _tokenService.CreateToken(user);

            var response = new AccountResponse()
            {
                Username = user.UserName,
                Email = user.Email,
                Role = role,
                Token = token
            };

            return response.AuthenticationOk();
        }
    }
}
