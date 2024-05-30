using Microsoft.AspNetCore.Identity;
using School_management.DTOs;
using School_management.Methods;
using School_management.Models;
using School_management.Repositories.Teacher_Repository;

namespace School_management.Services
{
    public class RegistrationTeacherServices
    {
        public static async Task<ServiceResponse<Teacher>> LoginTeacherService(string NiNo , string Password) 
        {
            Teacher teacher = await TeacherRepository.GetTeacherByNiNo(NiNo);
            await AccessMethods.VerifyPassword(teacher ,Password);

            teacher.Password = string.Empty;
            var serviceResponse = new ServiceResponse<Teacher>(teacher, true, "");

            return serviceResponse;
        }
    }
}
