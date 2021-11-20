using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.API.Controllers.Base;
using Condominio.Application.DTOs;
using Condominio.Application.Models.Condominium;
using Condominio.Application.Products.Commands.Condominium;
using Condominio.Application.Products.Queries.Condominium;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Condominio.Application.Models;

namespace Condominio.API.Controllers.v1
{
    public class CondominiumController : ApiController
    {
        public CondominiumController(IMediator mediator, IServiceProvider serviceProvider) : base(mediator, serviceProvider) {}

        [HttpGet]
        public async Task<IActionResult> GetAllCondominiums() =>
            await ExecuteQueryAsync<GetAllCondominiumsQuery, IEnumerable<GetAllCondominiumsResponse>>();

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCondominiumById(Guid id) =>
            await ExecuteQueryAsync<GetCondominiumByIdQuery, GetCondominiumByIdResponse>(new GetCondominiumByIdQuery(id));

        [HttpPost]
        public async Task<IActionResult> CreateCondominium([FromBody] CreateCondominiumRequest command) => 
            await ExecuteCommandAsync<CreateCondominiumCommand, Guid>(new CreateCondominiumCommand(command.Name, command.Address));
    }
}
