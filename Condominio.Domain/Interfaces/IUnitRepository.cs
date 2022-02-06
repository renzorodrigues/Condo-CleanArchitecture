using Condominio.Domain.Models;
using System;
using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces
{
    public interface IUnitRepository
    {
        Task<UnitsPagedResponse> GetUnitsPagedByBlockId(Guid blockId, int pageNumber, int pageSize);
    }
}