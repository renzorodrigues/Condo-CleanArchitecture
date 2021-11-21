using Condominio.Domain.Entities.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Condominio.Domain.Entities
{
    public sealed class ApplicationUser : BaseEntity
    {
        public string Name { get; private set; }
        public string CPF { get; private set; }
        public string CellPhone { get; private set; }        
        public Guid CredentialId { get; set; }
        public short? ApplicationUserTypeCode { get; set; }
        [NotMapped]
        public ApplicationUserType ApplicationUserType { get; set; }
        [NotMapped]
        public Credential Credential { get; set; }

        public Guid GetGuid() => base.Id;
        public void SetApplicationUserData()
        {
            this.Name = " ";
        }
    }
}