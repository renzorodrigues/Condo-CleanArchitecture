using System.Collections.Generic;
using System.Linq;
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
                .Include(a => a.Address)
                .Include(b => b.Blocks).ThenInclude(u => u.Units)
                .ToListAsync();
            return condominiums;
        }
    }
}
