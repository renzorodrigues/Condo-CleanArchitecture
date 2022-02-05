using Condominio.Application.Interfaces.Services;
using Condominio.Domain.Entities.Account;
using Condominio.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Condominio.Service.AuthService
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IAccountRepository _accountRepository;
        public TokenService(IConfiguration configuration, IAccountRepository accountRepository)
        {
            this._configuration = configuration;
            this._accountRepository = accountRepository;
        }

        public async Task<string> CreateToken(AppUser user)
        {
            var role = await _accountRepository.GetRole(user);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                new Claim(ClaimTypes.Role, role)
            };            

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("TokenKey").Value));

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
    }
}
