using System;
using System.Linq;
using System.Threading.Tasks;
using Condominio.Application.Models.Unit;
using Condominio.Domain.Interfaces;
using Condominio.Domain.Models;
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

        public async Task<UnitsPagedResponse> GetUnitsPagedByBlockId(Guid blockId, int pageNumber, int pageSize)
        {
            var totalResults = await dbContext.Units
                .Where(x => x.BlockId == blockId)
                .CountAsync();

            var units = await dbContext.Units
                .AsNoTracking()
                .Include(x => x.UnitUsers)
                .Where(x =>  x.BlockId == blockId)
                .OrderBy(x => x.Code)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new UnitsPagedResponse(units, pageNumber, pageSize, totalResults);
        }
    }
}
