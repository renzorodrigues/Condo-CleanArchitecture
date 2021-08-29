using Condominio.Domain.Entities.Base;

namespace Condominio.Domain.Entities
{
  public sealed class Unit : EntityBase
    {
        public int Number { get; private set; }

        public User Owner { get; private set; }

        public Unit(int number, User owner)
        {
            this.Number = number;
            this.Owner = owner;
        }

        public void Update(int number)
        {
            this.Number = number;
        }
    }
}
