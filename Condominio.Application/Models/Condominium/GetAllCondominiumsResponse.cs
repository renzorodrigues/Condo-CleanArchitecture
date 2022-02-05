using Condominio.Application.DTOs;
using System;

namespace Condominio.Application.Models.Condominium
{
    public class GetAllCondominiumsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}
