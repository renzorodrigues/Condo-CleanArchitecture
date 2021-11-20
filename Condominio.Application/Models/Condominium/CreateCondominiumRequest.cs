using Condominio.Application.DTOs;

namespace Condominio.Application.Models.Condominium
{
    public class CreateCondominiumRequest
    {
        public string Name { get; set; }
        public AddressDto Address { get; set; }
    }
}
