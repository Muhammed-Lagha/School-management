using Microsoft.AspNetCore.Mvc;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Methods;
using School_management.Models;

namespace School_management.Controllers.Student_Controller
{
    [Route("api/Student/[controller]")]
    [ApiController]
    public class StudentRegistrationController : ControllerBase
    {
        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResponse<Student>>> StuRegistration([FromBody] StudentsRequests studentsRequests)
        {
            try
            {
                var db = new SchoolManagementContext();

                string hashedPassword = AccessMethods.GenerateHash(studentsRequests.Passwrod);
                DateOnly birthDate = ParseDate.ParseDateOnly(studentsRequests.DateOfBirth);

                Student student = new Student();

                student.FirstName = studentsRequests.FirstName;
                student.LastName = studentsRequests.LastName;
                student.DateOfBirth = birthDate;
                student.Password = hashedPassword;

                db.Students.Add(student);
                await db.SaveChangesAsync();

                var serviceResponse = new ServiceResponse<Teacher>(student, true, "");
                return Ok(serviceResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        
    }
}
