using Condominio.Domain.Entities.Account;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Condominio.Domain.Interfaces
{
    public interface IAccountRepository
    {
        Task<IdentityResult> Register(AppUser entity, string password);
        Task<AppUser> Login(AppUser entity);
        Task AddUserRole(AppUser user, string role);
        Task<string> GetRole(AppUser user);
    }
}
