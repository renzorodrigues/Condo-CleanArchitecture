using Condominio.Application.DTOs;
using Condominio.Core.Handlers.Interfaces;
using System;

namespace Condominio.Application.Products.Commands.Condominium
{
    public class CreateCondominiumCommand : ICommand<Guid>
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }

        public CreateCondominiumCommand(string name, AddressDto address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
}
