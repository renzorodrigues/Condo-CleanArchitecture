using Condominio.Core.Helpers;

namespace Condominio.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Credentials EncryptPassword(string password);
    }
}
