using Condominio.Application.Models.Condominium;
using Condominio.Core.Handlers;
using System.Collections.Generic;

namespace Condominio.Application.Products.Queries.Condominium
{
    public class GetAllCondominiumsQuery : Query<IEnumerable<GetAllCondominiumsResponse>>
    {
    }
}
