using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School_management.DTOs;
using School_management.DTOs.RequestDTOs;
using School_management.Models;

namespace School_management.Controllers.Teacher_Controller
{
    [Route("api/[controller]")]
    [ApiController ,Authorize]
    public class TeacherSubjectController : ControllerBase
    {
        private readonly SchoolManagementContext _db;

        public TeacherSubjectController (SchoolManagementContext db)
        {
            _db = db;
        }

        [HttpPost("CreateSubject"), Authorize(Roles = "Teacher")]
        public async Task<ActionResult<ServiceResponse<Subject>>> CreateSubject([FromBody] CreateSubjectRequests createSubject)
        {
            try 
            {
                if (createSubject == null)
                {
                    throw new ArgumentNullException(nameof(createSubject));
                }
                
                Subject subject = new Subject
                {
                    Name = createSubject.Name,
                    GradeId = createSubject.GradeId,
                    GradeNumber = createSubject.GradeNumber
                };

                _db.Subjects.Add(subject);
                await _db.SaveChangesAsync();

                var serviceResponse = new ServiceResponse<Subject>(subject ,true ,"");
                return Ok(serviceResponse);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
            
        }

        [HttpPut("EditSubject/{id}"), Authorize(Roles = "Teacher")]
        public async Task<ActionResult<ServiceResponse<Subject>>> EditSubject(int id, [FromBody] UpdateSubjectRequest updateSubjectRequest)
        {
            try
            {
                // Find the subject to be updated 
                var subject = await _db.Subjects.FindAsync(id);

                if (subject == null)
                {
                    return NotFound($"Subject with ID {id} not found.");
                }

                // Update the subject properties
                subject.Name = updateSubjectRequest.Name;
                subject.GradeId = updateSubjectRequest.GradeId;
                subject.GradeNumber = updateSubjectRequest.GradeNumber;

                // Save the changes to the database
                await _db.SaveChangesAsync();

                var serviceResponse = new ServiceResponse<Subject>(subject, true, "");
                return Ok(serviceResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
