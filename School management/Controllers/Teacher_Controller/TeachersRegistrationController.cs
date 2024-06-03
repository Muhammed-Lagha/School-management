using Microsoft.AspNetCore.Mvc;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Methods;
using School_management.Models;
using School_management.Services;

namespace School_management.Controllers.Teacher_Controller
{
    [Route("api/[controller]")]
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
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<ServiceResponse<Teacher>>> Registration([FromBody] CreateTeacher createTeacher)
        {
            try
            {
                var db = new SchoolManagementContext();

                if (createTeacher == null)
                {
                    return BadRequest();
                }
                if (createTeacher.Id > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                // await AccessMethods.GenerateHash(createTeacher.Passwrod); // <= *
                createTeacher.Id = db.Teachers.OrderByDescending(u => u.Id ).FirstOrDefault().Id + 1;

                var serviceResponse = new ServiceResponse<CreateTeacher>(createTeacher, true, "");
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {

                throw new Exception("Erorr");
            }
        }
    }
}
