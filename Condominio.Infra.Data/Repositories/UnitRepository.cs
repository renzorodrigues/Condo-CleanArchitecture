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
    public class UnitRepository : IUnitRepository
    {
        private readonly DataBaseContext dbContext;

        public UnitRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Unit>> GetUnitsByBlockId(Guid blockId)
        {
            var units = await dbContext.Units
                .Where(x =>  x.BlockId == blockId)
                .OrderBy(x => x.Code)
                .ToListAsync();
            return units;
        }
    }
}
