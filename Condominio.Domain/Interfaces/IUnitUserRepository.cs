using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;

namespace Condominio.Domain.Interfaces
{
    public interface IUnitUserRepository
    {
         Task<IEnumerable<UnitUser>> GetUnitUsers();
    }
}