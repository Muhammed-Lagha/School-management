using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPut("EditGrade/{id}"), Authorize(Roles = "Teacher")]
        public async Task<ActionResult<ServiceResponse<Grade>>> EditGrade(int id, [FromBody] UpdateGradeRequest updateGradeRequest)
        {
            try
            {
                var db = new SchoolManagementContext();

                // Find the subject to be updated 
                var grade = await db.Grades.FindAsync(id);

                if (grade == null)
                {
                    return NotFound($"grade with ID {id} not found.");
                }

                // Update the subject properties
                grade.Name = updateGradeRequest.GradeName;
                grade.GradeNumber = updateGradeRequest.GradeNumber;

                // Save the changes to the database
                await db.SaveChangesAsync();

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
