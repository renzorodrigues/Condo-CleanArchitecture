using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Core.Entities;

namespace Condominio.Core.Interfaces
{
    public interface IUserRepository
    {
         Task<IEnumerable<User>> GetUsers();
    }
}