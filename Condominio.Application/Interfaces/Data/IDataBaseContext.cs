using Condominio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Condominio.Application.Interfaces.Data
{
    public interface IDataBaseContext
    {
        DbSet<Unit> Unit { get; }
    }
}