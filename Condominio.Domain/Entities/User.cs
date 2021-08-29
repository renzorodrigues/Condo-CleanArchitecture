using System;
using Condominio.Domain.Entities.Base;

namespace Condominio.Domain.Entities
{
    public sealed class User : EntityBase
    {
        public string Name { get; private set; }

        public User(string name)
        {
            this.Validate(name);
        }

        private void Validate(string name)
        {
            this.Name = name.Length < 5 ? throw new Exception() : name;
        }
    }
}