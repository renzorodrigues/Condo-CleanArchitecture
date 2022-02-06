using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Condominio.Application.Models.Unit;
using Condominio.Application.Products.Queries.Unit;

namespace Condominio.API.Controllers.v1
{
    // [Authorize]
    public class UnitController : ApiController
    {
        public UnitController(IMediator mediator, IServiceProvider serviceProvider) : base(mediator, serviceProvider) { }

        [HttpGet("{blockId}/{pageNumber:int}/{pageSize:int}")]
        public async Task<IActionResult> GetUnitsPagedByBlockId(Guid blockId, int pageNumber = 1, int pageSize = 10) =>
            await ExecuteQueryAsync<GetUnitsPagedQuery, GetUnitsPagedResponse>(new GetUnitsPagedQuery(blockId, pageNumber, pageSize));
    }
}
