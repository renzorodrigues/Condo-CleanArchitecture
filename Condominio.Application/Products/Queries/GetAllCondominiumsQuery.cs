using Condominio.Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Condominio.Application.Products.Queries
{
    public class GetAllCondominiumsQuery : IRequest<IEnumerable<Condominium>>
    {
    }
}
