using Condominio.Application.Models.Unit;
using Condominio.Core.Handlers;
using System;

namespace Condominio.Application.Products.Queries.Unit
{
    public class GetUnitsPagedQuery : Query<GetUnitsPagedResponse>
    {
        public Guid BlockId { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetUnitsPagedQuery(Guid blockId, int pageNumber, int pageSize)
        {
            this.BlockId = blockId;
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 25 ? 25 : pageSize;
        }
    }
}
