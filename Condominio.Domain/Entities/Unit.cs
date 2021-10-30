using Condominio.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
  public sealed class Unit : Entity
    {
        public string Code { get; private set; }
        public double Size { get; private set; }
        public ICollection<User> Users { get; set; }
        public Guid BlockId { get; set; }
        public Block Block { get; set; }
    }
}
