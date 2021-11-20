using Condominio.Application.Interfaces.Services;
using Condominio.Core.Helpers;
using System.Security.Cryptography;
using System.Text;

namespace Condominio.Service.AuthService
{
    public class AuthService : IAuthService
    {
        public Credentials EncryptPassword(string password)
        {
            byte[] salt = CreateSalt();
            byte[] hash = CreateHash(password, salt);

            return new Credentials()
            {
                PasswordSalt = salt,
                PasswordHash = hash
            };
        } 

        private static byte[] CreateSalt()
        {
            byte[] salt = new byte[10];

            using (var rgb = RandomNumberGenerator.Create())
            {
                rgb.GetBytes(salt);
            }

            return salt;
        }

        private static byte[] CreateHash(string password, byte[] salt)
        {
            byte[] hash;
            string passwordSalted = password + salt;

            using (var hmac = new SHA256CryptoServiceProvider())
            {
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordSalted));
            }

            return hash;
        }
    }
}
