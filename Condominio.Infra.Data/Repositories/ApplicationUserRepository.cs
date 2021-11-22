using System.Collections.Generic;
using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Repositories
{
    public class ApplicationUserRepository : IApplicationUserRepository
    {
        private readonly DataBaseContext dbContext;

        public ApplicationUserRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task CreateApplicationUser(ApplicationUser entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
