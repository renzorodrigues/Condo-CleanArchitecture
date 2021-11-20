using Condominio.Core.Handlers.Interfaces;
using System;

namespace Condominio.Application.Products.Commands.Account
{
    public class CreateAccountCommand : ICommand<Guid>
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

        public CreateAccountCommand(string username, string password, string email)
        {
            this.Username = username;
            this.Password = password;
            this.Email = email;
        }
    }
}
