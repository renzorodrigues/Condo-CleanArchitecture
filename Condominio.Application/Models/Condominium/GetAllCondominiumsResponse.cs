using System;

namespace Condominio.Application.DTOs
{
    public class GetAllCondominiumsResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}
