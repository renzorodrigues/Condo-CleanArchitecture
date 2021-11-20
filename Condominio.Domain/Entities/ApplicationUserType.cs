using System;
using System.Collections.Generic;

namespace Condominio.Domain.Entities
{
    public sealed class ApplicationUserType
    {
        public short Code { get; private set; }
        public string Description { get; private set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationUserType(short code, string description)
        {
            this.Code = code;
            this.Description = description;
        }
    }
}