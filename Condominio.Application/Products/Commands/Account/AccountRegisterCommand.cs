using Condominio.Core.Handlers.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;

namespace Condominio.Application.Products.Commands.Account
{
    public class AccountRegisterCommand : ICommand<IdentityResult>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountRegisterCommand(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
