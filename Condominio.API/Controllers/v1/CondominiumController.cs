using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.API.Controllers.Base;
using Condominio.Application.Models;
using Condominio.Application.Products.Commands;
using Condominio.Application.Products.Commands.Requests;
using Condominio.Application.Products.Commands.Responses;
using Condominio.Application.Products.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Condominio.API.Controllers.v1
{
    public class CondominiumController : ApiController
    {
        public CondominiumController(IMediator mediator, IServiceProvider serviceProvider) : base(mediator, serviceProvider) {}

        [HttpGet]
        public async Task<IActionResult> GetAllCondominiums() =>
            await ExecuteQueryAsync<GetAllCondominiumsQuery, IEnumerable<CondominiumResponse>>(new GetAllCondominiumsQuery());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCondominiumById(Guid id) =>
            await ExecuteQueryAsync<GetCondominiumByIdQuery, CondominiumByIdResponse>(new GetCondominiumByIdQuery(id));

        [HttpPost]
        public async Task<IActionResult> CreateCondominium([FromBody] CreateCondominiumRequest command) => 
            await ExecuteCommandAsync<CreateCondominiumCommand, CreateCondominiumResponse>(new CreateCondominiumCommand(command.Name, command.Address));
    }
}