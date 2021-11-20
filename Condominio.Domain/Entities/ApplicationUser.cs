using Condominio.Domain.Entities.Base;
using System;

namespace Condominio.Domain.Entities
{
    public sealed class ApplicationUser : BaseEntity
    {
        public string Name { get; private set; }
        public Credential Credential { get; private set; }
        public string Email { get; private set; }
        public short? ApplicationUserTypeCode { get; set; }
        public ApplicationUserType ApplicationUserType { get; set; }

        public Guid GetGuid() => base.Id;
        public void SetEmail(string email) => this.Email = email;
    }
}