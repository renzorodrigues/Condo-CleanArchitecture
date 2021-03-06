using Condominio.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public sealed class Unit : BaseEntity
    {
        public string Code { get; private set; }
        public double Size { get; private set; }
        public ICollection<UnitUser> UnitUsers { get; private set; }
        public bool IsRented { get; private set; }
        public Guid BlockId { get; set; }
        public Block Block { get; set; }
    }
}
