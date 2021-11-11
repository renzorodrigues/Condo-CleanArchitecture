using Condominio.Application.DTOs;
using Condominio.Application.Products.Commands.Responses;
using MediatR;
using System;

namespace Condominio.Application.Products.Commands.Requests
{
    public class CreateCondominiumRequest : IRequest<CreateCondominiumResponse>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}
