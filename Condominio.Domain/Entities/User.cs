using System;
using Condominio.Domain.Entities.Base;

namespace Condominio.Domain.Entities
{
    public sealed class User : Entity
    {
        public string Name { get; private set; }
        public Guid UnitId { get; set; }
        public Unit Unit { get; set; }

        public User(string name, Guid unitId)
        {
            this.Name = this.Validate(name);
            this.UnitId = unitId;
        }

        private string Validate(string name)
        {
            return name.Length < 5 ? throw new Exception() : name;
        }
    }
}