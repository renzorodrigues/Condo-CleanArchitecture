using Condominio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Condominio.Domain.Models
{
    public class UnitsPagedResponse
    {
        public IEnumerable<Unit> Units { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalResults { get; set; }

        public UnitsPagedResponse(IEnumerable<Unit> units, int pageNumber, int pageSize, int totalResults)
        {
            this.Units = units;
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.TotalPages = ((int)Math.Ceiling((double)totalResults / (double)pageSize));
            this.TotalResults = totalResults;
        }
    }
}
