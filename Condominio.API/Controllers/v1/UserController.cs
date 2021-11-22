using Condominio.API.Controllers.Base;
using Condominio.Application.Models.ApplicationUser;
using Condominio.Application.Products.Commands.ApplicationUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Condominio.API.Controllers.v1
{
    public class UserController : ApiController
    {
        public UserController(IMediator mediator, IServiceProvider serviceProvider) : base(mediator, serviceProvider)
        {
        }

        [HttpPost]
        public async Task<IActionResult> CreateCondominium([FromBody] CreateApplicationUserRequest command, Guid credentialId) =>
            await ExecuteCommandAsync<CreateApplicationUserCommand, Guid>(new CreateApplicationUserCommand(command.Name, command.CPF, command.CellPhone, credentialId));
    }
}