using Condominio.Core.Handlers.Interfaces;
using System;

namespace Condominio.Application.Products.Commands.Credential
{
    public class CreateCredentialCommand : ICommand<Guid>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public CreateCredentialCommand(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
