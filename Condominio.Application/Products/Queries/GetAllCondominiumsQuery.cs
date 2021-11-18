using Condominio.Application.Models;
using Condominio.Core.Handlers;
using System.Collections.Generic;

namespace Condominio.Application.Products.Queries
{
    public class GetAllCondominiumsQuery : Query<IEnumerable<CondominiumResponse>>
    {
    }
}
