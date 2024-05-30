using Org.BouncyCastle.Crypto.Generators;
using School_management.Models;
using System.Security.Cryptography;

namespace School_management.Methods
{
    public class AccessMethods
    {
        public static async Task VerifyPassword(Teacher teacher, string clientPassword)
        {

            bool isMatch = BCrypt.Equals(teacher.Password, clientPassword);

            if (!isMatch)
            {
                throw new Exception("Invalid NiNo or Password");
            }
        }

        public string GenerateHash(string password)
        {
            //using (var hmac = new HMACSHA512())
            //{
            //    passwordSalt = hmac.Key;
            //    passwordHashed = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            //}
            string salt = BCrypt.Net.BCrypt.GenerateSalt(); // Generate a random salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt); // Generate the hash

            return hashedPassword;
        }
    }
}
