using Condominio.API.Controllers.Base;
using Condominio.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        public async Task<ActionResult<User>> Register([FromServices] IMediator mediator, string username, string password)
        {
            return new User();
        }
    }
}
