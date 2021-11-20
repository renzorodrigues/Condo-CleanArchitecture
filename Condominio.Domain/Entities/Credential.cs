using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Condominio.Domain.Entities
{
    public sealed class Credential
    {
        public string Username { get; private set; }
        public string Password { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public Guid ApplicationUserId { get; set; }
        [NotMapped]
        public ApplicationUser ApplicationUser { get; set; } = new ApplicationUser();

        public Credential(string username, string password)
        {
            this.Username = username;
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
