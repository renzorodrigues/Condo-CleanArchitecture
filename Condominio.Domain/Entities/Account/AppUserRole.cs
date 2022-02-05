using Microsoft.AspNetCore.Identity;
using System;

namespace Condominio.Domain.Entities.Account
{
    public class AppUserRole : IdentityUserRole<Guid>
    {
        public AppUser User { get; set; }
        public AppRole Role { get; set; }
    }
}
