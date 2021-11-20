using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;

namespace Condominio.Domain.Interfaces
{
    public interface IResidentRepository
    {
         Task<IEnumerable<Resident>> GetResidents();
    }
}