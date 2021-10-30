using System;

namespace Condominio.Domain.Entities.Base
{
    public abstract class Entity
    {
        public Guid Id { get; protected set; }

        public Entity()
        {
            this.Id = Guid.NewGuid();
        }
    }
}