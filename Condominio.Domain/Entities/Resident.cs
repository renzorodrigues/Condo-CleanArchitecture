using System;
using Condominio.Domain.Entities.Base;

namespace Condominio.Domain.Entities
{
    public sealed class Resident : BaseEntity
    {
        public string Name { get; private set; }
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}