using Condominio.Application.Models.Credential;
using Condominio.Core.Handlers.Interfaces;
using System;

namespace Condominio.Application.Products.Commands.Credential
{
    public class CreateTokenCommand : ICommand<CredentialTokenResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public CreateTokenCommand(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }
    }
}
