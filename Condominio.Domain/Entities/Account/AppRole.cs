using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities.Account
{
    public class AppRole : IdentityRole<Guid>
    {        
        public ICollection<AppUserRole> UserRoles { get; set; }
    }
}
