using School_management.Models;

namespace School_management.Methods
{
    public class AccessMethods 
    {


        public static async Task VerifyPass(Teacher teacher, string clientPassword)
        {

            bool isMatch = BCrypt.Net.BCrypt.Verify(clientPassword, teacher.Password);

            if (!isMatch)
            {
                throw new Exception("Invalid NiNo or Password");
            }
        }

        public string GenerateHash(string password)
        {
            string salt = BCrypt.Net.BCrypt.GenerateSalt(); 
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }
    }
}
