using System;
using System.Linq;
using System.Threading.Tasks;
using Condominio.Domain.Entities;
using Condominio.Domain.Interfaces;
using Condominio.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Infra.Data.Repositories
{
    public class CredentialRepository : ICredentialRepository
    {
        private readonly DataBaseContext dbContext;

        public CredentialRepository(DataBaseContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Credential> Authenticate(string email)
        {
            return await dbContext.Credentials
                .Include(x => x.ApplicationUsers)
                .Where(x => x.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task CreateCredential(Credential entity)
        {
            dbContext.Add(entity);
            await dbContext.SaveChangesAsync();
        }
    }
}
