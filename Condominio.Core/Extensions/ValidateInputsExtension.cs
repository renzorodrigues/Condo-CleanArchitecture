using System.Text.RegularExpressions;

namespace Condominio.Core.Extensions
{
    public static class ValidateInputsExtension
    {
        public static bool PasswordHasNumber(this string password) => new Regex(@"[0-9]+").IsMatch(password);
        public static bool PasswordHasUpperChar(this string password) => new Regex(@"[A-Z]+").IsMatch(password);
        public static bool PasswordHasLowerChar(this string password) => new Regex(@"[a-z]+").IsMatch(password);
        public static bool PasswordHasMinimum8Chars(this string password) => new Regex(@".{8,}").IsMatch(password);
        public static bool Email(this string email) => new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$").IsMatch(email);
    }
}
