using School_management.DTOs;
using School_management.Methods;
using School_management.Models;
using School_management.Repositories.Student_Repository;

namespace School_management.Services.Student_Service
{
    public class RegistrationStudentServices
    {
        public RegistrationStudentServices() { }
        public static async Task<ServiceResponse<Teacher>> LoginStudentService(string Name, string Password)
        {
            Student stu = await StudentRepository.GetStudentByName(Name);
            await AccessMethods.VerifyStudentPass(stu, Password);

            stu.Password = string.Empty;
            var serviceResponse = new ServiceResponse<Teacher>(stu, true, "");

            return serviceResponse;
        }
        
    }
}
