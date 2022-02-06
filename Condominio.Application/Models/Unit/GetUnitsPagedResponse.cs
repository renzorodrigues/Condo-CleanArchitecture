using System.Collections.Generic;

namespace Condominio.Application.Models.Unit
{
    public class GetUnitsPagedResponse
    {
        public IEnumerable<Domain.Entities.Unit> Units { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }

        public GetUnitsPagedResponse(IEnumerable<Domain.Entities.Unit> units, int pageNumber, int pageSize, int totalPages, int totalResults)
        {
            this.Units = units;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = totalPages;
            this.TotalResults = totalResults;
        }
    }
}
