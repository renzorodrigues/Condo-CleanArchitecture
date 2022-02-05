using Condominio.Application.Models.Unit;
using Condominio.Core.Handlers;
using System;
using System.Collections.Generic;

namespace Condominio.Application.Products.Queries.Unit
{
    public class GetAllUnitsQuery : Query<IEnumerable<GetAllUnitsResponse>>
    {
        public Guid BlockId { get; set; }

        public GetAllUnitsQuery(Guid blockId)
        {
            this.BlockId = blockId;
        }
    }
}
