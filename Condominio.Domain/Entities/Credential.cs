using Condominio.Domain.Entities.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Condominio.Domain.Entities
{
    public sealed class Credential : BaseEntity
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        [NotMapped]
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public Credential(string email, string password)
        {
            this.Email = email;
            this.Password = password;
        }

        public void SetPasswords(byte[] passwordHash, byte[] passwordSalt)
        {
            this.PasswordHash = passwordHash;
            this.PasswordSalt = passwordSalt;
            this.Password = string.Empty;
        }
    }
}
