using Condominio.Application.Models.Account;
using Condominio.Core.Handlers.Interfaces;

namespace Condominio.Application.Products.Commands.Account
{
    public class AccountLoginCommand : ICommand<AccountResponse>
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public AccountLoginCommand(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
