using Condominio.Application.Models;
using Condominio.Application.Products.Commands.Responses;
using Condominio.Core.Helpers;
using MediatR;
using System;

namespace Condominio.Application.Products.Commands.Requests
{
    public class CreateCondominiumCommand : IRequest<Result<CreateCondominiumResponse>>
    {
        public string Name { get; set; }
        public AddressResponse Address { get; set; }

        public CreateCondominiumCommand(string name, AddressResponse address)
        {
            this.Name = name;
            this.Address = address;
        }
    }
}
