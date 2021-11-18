using Condominio.Application.Models;
using Condominio.Core.Handlers;
using System;

namespace Condominio.Application.Products.Queries
{
    public class GetCondominiumByIdQuery : Query<CondominiumByIdResponse>
    {
        public Guid Id { get; set; }

        public GetCondominiumByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
