using Condominio.Application.DTOs;

namespace Condominio.Application.Models.ApplicationUser
{
    public class CreateApplicationUserRequest
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string CellPhone { get; set; }
    }
}
