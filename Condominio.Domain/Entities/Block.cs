using Condominio.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public sealed class Block : EntityBase
    {
        public string Name { get; private set; }
        public short? NumberOfLifts { get; private set; }
        public Guid CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
        public ICollection<Unit> Units { get; private set; }
    }
}
