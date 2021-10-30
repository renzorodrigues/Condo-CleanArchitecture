using Condominio.Domain.Entities.Base;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public sealed class Condominium : Entity
    {
        public string Name { get; private set; }
        public Address Address { get; private set; }
        public ICollection<Block> Blocks { get; private set; }

        public Condominium()
        {

        }

        public Condominium(string name, Address address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
}
