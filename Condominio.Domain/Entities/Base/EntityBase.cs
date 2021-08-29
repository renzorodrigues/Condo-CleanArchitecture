using System;

namespace Condominio.Domain.Entities.Base
{
    public abstract class EntityBase
    {
        public Guid Id { get; protected set; }

        public EntityBase()
        {
            this.Id = Guid.NewGuid();
        }
    }
}