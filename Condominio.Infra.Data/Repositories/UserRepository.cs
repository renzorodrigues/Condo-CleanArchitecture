using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;

namespace Condominio.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        public Task<IEnumerable<User>> GetUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
