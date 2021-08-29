using System;
using Condominio.Core.Entities.Base;

namespace Condominio.Core.Entities
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