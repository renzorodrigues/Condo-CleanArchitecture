using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataBaseContext dbContext;

        public UserRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await dbContext.Users.Include(u => u.Unit).ToListAsync();
            return users;
        }
    }
}
