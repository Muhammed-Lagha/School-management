using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Org.BouncyCastle.Crypto;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Models;

namespace School_management.Controllers.Teacher_Controller
{
    [Route("api/[controller]")]
    [ApiController , Authorize]
    
    public class TeacherGradeController : ControllerBase
    {
        private readonly SchoolManagementContext _db;
        public TeacherGradeController (SchoolManagementContext db)
        {
            _db = db;
        }

        [HttpPost("CreateGrade") , Authorize(Roles = "Teacher")]
        public async Task<ActionResult<ServiceResponse<Grade>>> CreateGrade(CreateGradeRequests gradeRequests)
        {
            try
            {
                Grade grade = new Grade {
                    GradeNumber = gradeRequests.GradeNumber,
                    Name = gradeRequests.GradeName,
                };

                _db.Add(grade);
                await _db.SaveChangesAsync();

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
                var grade = await _db.Grades.FindAsync(id);

                if (grade == null)
                {
                    return NotFound($"grade with ID {id} not found.");
                }

                grade.Name = updateGradeRequest.GradeName;
                grade.GradeNumber = updateGradeRequest.GradeNumber;

                await _db.SaveChangesAsync();

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
