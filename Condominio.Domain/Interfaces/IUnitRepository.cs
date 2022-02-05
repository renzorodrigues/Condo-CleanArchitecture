using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;

namespace Condominio.Domain.Interfaces
{
    public interface IUnitRepository
    {
        Task<IEnumerable<Unit>> GetUnitsByBlockId(Guid blockId);
    }
}