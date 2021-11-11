using Condominio.Application.Interfaces.Services;
using Condominio.Application.Products.Commands.Requests;
using Condominio.Application.Products.Queries;
using Condominio.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Condominio.Application.Services
{
    public class CondominiumService : ICondominiumService
    {
        private readonly IMediator _mediator;

        public CondominiumService(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public async Task<Guid> CreateCondominium(CreateCondominiumRequest request)
        {
            var result = await this._mediator.Send(request);
            return result.Id;
        }

        public async Task<IEnumerable<Condominium>> GetAllCondominiums()
        {
            var result = await _mediator.Send(new GetAllCondominiumsQuery());
            return result;
        }
    }
}
