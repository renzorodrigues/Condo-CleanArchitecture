using Condominio.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public sealed class Condominium : EntityBase
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Block> Blocks { get; private set; }
    }
}
