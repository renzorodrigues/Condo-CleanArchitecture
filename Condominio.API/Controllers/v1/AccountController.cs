using Condominio.API.Controllers.Base;
using Condominio.Application.Models.Account;
using Condominio.Application.Products.Commands.Account;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Condominio.API.Controllers.v1
{
    public class AccountController : ApiController
    {
        public AccountController(IMediator mediator, IServiceProvider serviceProvider) : base(mediator, serviceProvider)
        {
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAccount([FromBody] AccountRegisterRequest command) =>
            await ExecuteCommandAsync<AccountRegisterCommand, IdentityResult>(new AccountRegisterCommand(command.Username, command.Password));

        [HttpPost("login")]
        public async Task<IActionResult> LoginAccount([FromBody] AccountLoginRequest command) =>
            await ExecuteCommandAsync<AccountLoginCommand, AccountResponse>(new AccountLoginCommand(command.Username, command.Password));
    }
}
