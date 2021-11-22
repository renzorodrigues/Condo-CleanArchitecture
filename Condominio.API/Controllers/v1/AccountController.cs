using Condominio.API.Controllers.Base;
using Condominio.Application.Models.Credential;
using Condominio.Application.Products.Commands.Credential;
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
        public async Task<IActionResult> RegisterAccount([FromBody] CredentialRequest command) =>
            await ExecuteCommandAsync<CreateCredentialCommand, Guid>(new CreateCredentialCommand(command.Email, command.Password));

        [HttpPost("login")]
        public async Task<IActionResult> LoginAccount([FromBody] CredentialRequest command) =>
            await ExecuteCommandAsync<CreateTokenCommand, CredentialTokenResponse>(new CreateTokenCommand(command.Email, command.Password));
    }
}
