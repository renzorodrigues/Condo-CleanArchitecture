using Condominio.Domain.Entities.Base;
using Condominio.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public sealed class UnitUser : BaseEntity
    {
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string Email { get; private set; }
        public DateTime BirthDate { get; private set; }
        public ICollection<Telphone> Telphone { get; private set; }
        public UnitUserType UnitUserType { get; private set; }
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }
    }
}