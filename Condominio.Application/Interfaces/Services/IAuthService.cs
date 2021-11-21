using Condominio.Core.Helpers;

namespace Condominio.Application.Interfaces.Services
{
    public interface IAuthService
    {
        Credentials EncryptPassword(string password);
        byte[] CreateHash(string password, byte[] salt);
        string GenerateToken(string id, string email, string role);
        bool HashedPasswordsEquals(byte[] requestedPassword, byte[] entityPassword);
    }
}
