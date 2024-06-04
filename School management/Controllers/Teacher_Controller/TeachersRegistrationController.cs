using Microsoft.AspNetCore.Mvc;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Methods;
using School_management.Models;
using School_management.Services;

namespace School_management.Controllers.Teacher_Controller
{
    [Route("api/Teachers/[controller]")]
    [ApiController]
    public class TeachersRegistrationController : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<ServiceResponse<Teacher>>> Login([FromBody] LoginTeacherRequests loginTeacherRequests)
        {
            try 
            {
                var serviceResponseTeacher = await RegistrationTeacherServices.LoginTeacherService(loginTeacherRequests.NiNo, loginTeacherRequests.Password);
                return Ok(serviceResponseTeacher);
            }
            catch (Exception ex) 
            {
                var serviceResponse = new ServiceResponse<Teacher>(null!, false, ex.Message, null!);
                return BadRequest(serviceResponse);
            }
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResponse<Teacher>>> Registration([FromBody] CreateTeacher createTeacher)
        {
            try
            {
                var db = new SchoolManagementContext();

                string hashedPassword = AccessMethods.GenerateHash(createTeacher.Passwrod);
                DateOnly birthDate = ParseDate.ParseDateOnly(createTeacher.BirthDate);

                Teacher teacher = new Teacher
                {
                    FirstName = createTeacher.FirstName,
                    LastName = createTeacher.LastName,
                    NiNo = createTeacher.NeNo,
                    Password = hashedPassword,
                    BirthDate = birthDate,
                };

                db.Add(teacher);

                await db.SaveChangesAsync();
                var serviceResponse = new ServiceResponse<Teacher>(teacher, true, "");
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {

                throw new Exception("Erorr" ,ex);
            }
        }
    }
}
