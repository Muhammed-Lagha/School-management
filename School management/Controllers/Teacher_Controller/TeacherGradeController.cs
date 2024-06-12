using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Exchange.WebServices.Data;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Models;

namespace School_management.Controllers.Teacher_Controller
{
    [Route("api/[controller]")]
    [ApiController , Authorize]
    
    public class TeacherGradeController : ControllerBase
    {
        [HttpPost("CreateGrade") , Authorize(Roles = "Teacher")]
        public ActionResult<ServiceResponse<Grade>> CreateGrade(CreateGradeRequests gradeRequests)
        {
            try
            {
                var db = new SchoolManagementContext();

                Grade grade = new Grade {
                    GradeNumber = gradeRequests.GradeNumber,
                    Name = gradeRequests.GradeName
                };

                db.Add(grade);
                db.SaveChanges();

                var serviceResponse = new ServiceResponse<Grade>(grade, true, "");
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
