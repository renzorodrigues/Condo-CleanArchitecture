using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Repositories
{
    public class ResidentRepository : IResidentRepository
    {
        private readonly DataBaseContext dbContext;

        public ResidentRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Resident>> GetResidents()
        {
            var residents = await dbContext.Residents.Include(u => u.Unit).ToListAsync();
            return residents;
        }
    }
}
