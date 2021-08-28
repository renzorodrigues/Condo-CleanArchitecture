using System.Threading.Tasks;
using Condominio.Application.Interfaces.Email;
using Condominio.Application.Interfaces.Services;
using Condominio.Core.Entities;

namespace Condominio.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IEmailSender email;

        public UserService(IEmailSender email)
        {
            this.email = email;
        }
        public async Task<User> GetUserById()
        {
            //email.SimpleMessage();
            return new User("Renzo");
        }
    }
}