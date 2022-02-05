using System;

namespace Condominio.Application.Models.Unit
{
    public class GetAllUnitsResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public double Size { get; set; }
        public Guid BlockId { get; set; }
    }
}
