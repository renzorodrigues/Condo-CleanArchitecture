using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Repositories
{
    public class CondominiumRepository : ICondominiumRepository
    {
        private readonly DataBaseContext dbContext;

        public CondominiumRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Condominium>> GetCondominiums()
        {
            var condominiums = await dbContext.Condominiums
                .Include(b => b.Blocks)
                .ThenInclude(u => u.Units)
                .ThenInclude(u => u.Users)
                .ToListAsync();

            return condominiums;
        }
    }
}
