using Condominio.Domain.Entities.Base;
using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public sealed class Block : BaseEntity
    {
        public string Code { get; private set; }
        public short? NumberOfLifts { get; private set; }
        public ICollection<Unit> Units { get; private set; }
        public Guid CondominiumId { get; set; }
        public Condominium Condominium { get; set; }
    }
}
