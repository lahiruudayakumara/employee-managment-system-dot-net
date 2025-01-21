using System.Text;
using System.Security.Cryptography;


namespace EmployeeManagementSystem.Utilities
{
    public static class PasswordHasher
    {
        public static string HashPassword(string password)
        {
            using var hmac = new HMACSHA256();
            var salt = hmac.Key;
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(salt) + "." + Convert.ToBase64String(hash);
        }
    }
}