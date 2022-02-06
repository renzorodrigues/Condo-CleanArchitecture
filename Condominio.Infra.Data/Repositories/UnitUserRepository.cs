using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Repositories
{
    public class UnitUserRepository : IUnitUserRepository
    {
        private readonly DataBaseContext dbContext;

        public UnitUserRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<UnitUser>> GetUnitUsers()
        {
            var unitUsers = await dbContext.UnitUsers.Include(u => u.Unit).ToListAsync();
            return unitUsers;
        }
    }
}
