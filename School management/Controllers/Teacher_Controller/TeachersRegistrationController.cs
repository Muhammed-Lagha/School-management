
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using Org.BouncyCastle.Crypto.Generators;
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

        [HttpPost("regiser")]
        public async Task<ActionResult<ServiceResponse<Teacher>>> Registration([FromBody] CreateTeacher createTeacher)
        {
            try
            {
                AccessMethods.GenerateHash(createTeacher.Passwrod); // <= 
                var firstName = createTeacher.FirstName;
                var lastName = createTeacher.LastName;
                var password = createTeacher.Passwrod;
                var nino = createTeacher.NeNo;

                return Ok();
            }
            catch (Exception ex)
            {

                throw new Exception("Erorr");
            }
        }
    }
}
