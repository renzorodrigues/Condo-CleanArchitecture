using Condominio.API.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Condominio.API.Controllers.v1
{
    public class UserController : ApiController
    {
        public UserController(IMediator mediator, IServiceProvider serviceProvider) : base(mediator, serviceProvider)
        {
        }

        [HttpGet]
        public IActionResult GetUsers()
        {
            //var response = await this.userService.GetUsers();
            return Ok();
        }
    }
}