using Condominio.Application.Models;

namespace Condominio.Application.Products.Commands
{
    public class CreateCondominiumRequest
    {
        public string Name { get; set; }
        public AddressResponse Address { get; set; }
    }
}
