using System.Threading.Tasks;
using Condominio.Core.Entities;

namespace Condominio.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserById();
    }
}