using Microsoft.AspNetCore.Mvc;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Models;
using School_management.Services.Student_Service;

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
                var serviceResponse = await RegistrationStudentServices.RegisterStudentServices(studentsRequests);
                return Ok(serviceResponse);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ServiceResponse<Student>>> LoginStudent(StudentLoginRequest student)
        {
            try
            {
                var servicResponse = await RegistrationStudentServices.LoginStudentService(student.FirstName ,student.Password);
                return Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
