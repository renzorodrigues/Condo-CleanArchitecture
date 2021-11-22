using System;
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

        public async Task CreateCondominium(Condominium entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Condominium>> GetAllCondominiums()
        {
            var condominiums = await dbContext.Condominiums
                .Include(a => a.Address)
                .Include(b => b.Blocks)
                .ThenInclude(u => u.Units)
                .ThenInclude(u => u.Residents)
                .ToListAsync();

            return condominiums;
        }

        public async Task<Condominium> GetCondominiumById(Guid id)
        {
            var condominium = await dbContext.Condominiums
                .Include(b => b.Blocks.OrderBy(x => x.Code))
                .ThenInclude(u => u.Units.OrderBy(x => x.Code))
                .FirstOrDefaultAsync(x => x.Id == id);

            return condominium;
        }
    }
}
