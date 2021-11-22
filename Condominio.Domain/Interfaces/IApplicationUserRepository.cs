using Condominio.Domain.Entities;
using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces
{
    public interface IApplicationUserRepository
    {
         Task CreateApplicationUser(ApplicationUser entity);
    }
}