using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Condominio.Domain.Entities.Account
{
    public sealed class AppUser : IdentityUser<Guid>
    {
        [NotMapped]
        public string Password { get; private set; }
        public DateTime Created { get; private set; } = DateTime.Now;
        public DateTime LastActive { get; private set; } = DateTime.Now;

        public ICollection<AppUserRole> UserRoles { get; set; }

        public void UserNameToLower() => UserName = UserName.ToLower();
    }
}
