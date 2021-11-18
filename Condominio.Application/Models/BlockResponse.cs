using Condominio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Condominio.Application.Models
{
    public class BlockResponse
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public short? NumberOfLifts { get; set; }
        public ICollection<UnitResponse> Units { get; set; }
    }
}