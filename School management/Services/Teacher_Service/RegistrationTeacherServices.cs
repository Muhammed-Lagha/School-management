using DeviseHR_Server.Common;
using School_management.DTOs;
using School_management.Methods;
using School_management.Models;
using School_management.Repositories.Teacher_Repository;

namespace School_management.Services
{
    public class RegistrationTeacherServices
    {
        public static async Task<ServiceResponse<Teacher>> LoginTeacherService(string userName , string Password) 
        {
            Teacher teacher = await TeacherRepository.GetTeacherByUserName(userName);
            AccessMethods.VerifyTeacherPass(teacher ,Password);
            string token = await Tokens.GenerateTeacherAuthJWT(teacher);
            teacher.Password = string.Empty;
            var serviceResponse = new ServiceResponse<Teacher>(teacher, true, "", token);

            return serviceResponse;
        }
    }
}
