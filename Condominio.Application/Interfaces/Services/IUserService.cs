using System.Threading.Tasks;
using Condominio.Domain.Entities;

namespace Condominio.Application.Interfaces.Services
{
    public interface IUserService
    {
        Task<User> GetUserById();
    }
}