using School_management.Models;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace DeviseHR_Server.Common
{
    public static class Tokens
    {
        public static async Task<string> GenerateTeacherAuthJWT(Teacher teacher)
        {
            //string ddd = user.Company.AnnualLeaveStartDate.ToString()

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jwtSecrDD6huyukhjhjddddfdhjhjhjhhjhh#$3$3435343hhfhfh43434345465465465464645645645646545djddhjdhjdfdhet"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var claims = GenerateTeacherJwtClaims(teacher);

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(1600),
                signingCredentials: credentials,
                claims: claims // Add the claims to the token
            );

            var jwt = await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));

            return jwt;
        }

        public static List<Claim> GenerateTeacherJwtClaims(Teacher teacher)
        {
            var claims = new List<Claim>();

            
                claims = new List<Claim>
                {
                    new Claim("id", teacher.Id.ToString()),
                    new Claim("userName", teacher.Username.ToString()),
                    new Claim(ClaimTypes.Role ,"Teacher")
                };
            return claims;
        }

        public static async Task<string> GenerateStudentAuthJWT(Student student)
        {
            //string ddd = user.Company.AnnualLeaveStartDate.ToString()

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("jwtSecrDD6huyukhjhjddddfdhjhjhjhhjhh#$3$3435343hhfhfh43434345465465465464645645645646545djddhjdhjdfdhet"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var claims = GenerateStudentJwtClaims(student);

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddMinutes(1600),
                signingCredentials: credentials,
                claims: claims // Add the claims to the token
            );

            var jwt = await Task.Run(() => new JwtSecurityTokenHandler().WriteToken(token));

            return jwt;
        }

        public static List<Claim> GenerateStudentJwtClaims(Student student)
        {
            var claims = new List<Claim>();


            claims = new List<Claim>
                {
                    new Claim("id", student.StudentId.ToString()),
                    new Claim("userName", student.Username.ToString()),
                }; 
            return claims;
        }
    }
}
