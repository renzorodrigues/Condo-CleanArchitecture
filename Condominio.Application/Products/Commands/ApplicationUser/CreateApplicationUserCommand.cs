using Condominio.Core.Handlers.Interfaces;
using System;

namespace Condominio.Application.Products.Commands.ApplicationUser
{
    public class CreateApplicationUserCommand : ICommand<Guid>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CellPhone { get; set; }
        public Guid CredentialId { get; set; }

        public CreateApplicationUserCommand(string name, string cpf, string cellPhone, Guid credentialId)
        {
            this.Name = name;
            this.CPF = cpf;
            this.CellPhone = cellPhone;
            this.CredentialId = credentialId;
        }
    }
}
