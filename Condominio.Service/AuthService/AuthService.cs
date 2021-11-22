using Condominio.Application.Interfaces.Services;
using Condominio.Core.Helpers;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
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

        public byte[] CreateHash(string password, byte[] salt)
        {
            byte[] hash;
            string passwordSalted = password + salt;

            using (var hmac = new SHA256CryptoServiceProvider())
            {
                hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(passwordSalted));
            }

            return hash;
        }

        public string GenerateToken(string id, string email, string role, string tokenKey)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, id),
                new Claim(ClaimTypes.Name, email),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();

            var token = tokenHandler.CreateToken(tokenDescriptor);

            var tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }

        public bool HashedPasswordsEquals(byte[] requestedPassword, byte[] entityPassword)
        {
            return Convert.ToBase64String(requestedPassword).Equals(Convert.ToBase64String(entityPassword));
        }
    }
}
