using Condominio.Domain.Entities.Account;
using System.Threading.Tasks;

namespace Condominio.Application.Interfaces.Services
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}
