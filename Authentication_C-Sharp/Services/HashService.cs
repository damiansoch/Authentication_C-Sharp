using System.Security.Cryptography;
using System.Text;

namespace Authentication_C_Sharp.Services
{
    public class HashService
    {
        public static string HashPassword(string password)
        {
            using SHA256 sha256 = SHA256.Create();
            //converting password to hashed byte array
            byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            //converting to the string
            string hashedPassword = BitConverter.ToString(hashedBytes).Replace("-","").ToLower();
            return hashedPassword;
        }
    }
}
