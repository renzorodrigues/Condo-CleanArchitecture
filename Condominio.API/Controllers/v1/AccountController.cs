using Condominio.API.Controllers.Base;
using Condominio.Application.Models;
using Condominio.Application.Models.Account;
using Condominio.Application.Products.Commands.Account;
using MediatR;
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
        public async Task<IActionResult> RegisterAccount([FromBody] RegisterAccountRequest command) =>
            await ExecuteCommandAsync<CreateAccountCommand, Guid>(new CreateAccountCommand(command.Username, command.Password, command.Email));
    }
}
