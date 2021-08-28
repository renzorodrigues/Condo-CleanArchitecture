using System;

namespace Condominio.Core.Entities.Base
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