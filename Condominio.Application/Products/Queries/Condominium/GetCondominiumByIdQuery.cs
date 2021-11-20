using Condominio.Application.Models.Condominium;
using Condominio.Core.Handlers;
using System;

namespace Condominio.Application.Products.Queries.Condominium
{
    public class GetCondominiumByIdQuery : Query<GetCondominiumByIdResponse>
    {
        public Guid Id { get; set; }

        public GetCondominiumByIdQuery(Guid id)
        {
            this.Id = id;
        }
    }
}
