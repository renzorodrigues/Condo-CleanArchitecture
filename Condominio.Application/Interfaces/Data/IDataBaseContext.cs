using Condominio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Application.Interfaces.Data
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; }
        DbSet<Unit> Units { get; }
    }
}