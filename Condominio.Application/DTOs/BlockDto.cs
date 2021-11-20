using System;
using System.Collections.Generic;

namespace Condominio.Application.DTOs
{
    public class BlockDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public short? NumberOfLifts { get; set; }
        public ICollection<UnitDto> Units { get; set; }
    }
}