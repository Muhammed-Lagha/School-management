using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Methods;
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
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
                var servicResponse = await RegistrationStudentServices.LoginStudentService(student.UserName ,student.Password);
                return Ok(servicResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }
        [HttpGet("check-username/{username}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<bool>> CheckUsernameExists(string username)
        {
            try
            {
                var db = new SchoolManagementContext();
                var teacher = await db.Students.FirstOrDefaultAsync(t => t.Username == username);
                if (teacher == null)
                {
                    return NotFound(false);
                }
                return Ok(true);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
