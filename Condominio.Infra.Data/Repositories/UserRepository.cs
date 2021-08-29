using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Context;

namespace Condominio.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext dbContext;

        public UserRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public Task<IEnumerable<User>> GetUsers()
        {
            throw new System.NotImplementedException();
        }
    }
}
