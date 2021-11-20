namespace Condominio.Core.Helpers
{
    public class Credentials
    {
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}
