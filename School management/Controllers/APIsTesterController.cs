using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_management.DTOs;
using School_management.Models;

namespace School_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIsTesterController : ControllerBase
    {
        private readonly SchoolManagementContext _db;
        public APIsTesterController(SchoolManagementContext db)
        {
            _db = db;
        }

        [HttpPost("GetAllTeachers"), Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
        {
            try
            {
                List<Teacher> teacher = await _db.Teachers.ToListAsync();
                return Ok(teacher);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost("GetAllStudents")]
        [Authorize()]
        public async Task<ActionResult<List<Student>>> GetAllStudents()
        {
            try
            {
                List<Student> students = await _db.Students.ToListAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpGet("GetStudentById/{id}"), Authorize(Roles = "Teacher")]
        [Authorize()]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            try
            {
                //if (id == null) return BadRequest("");
                var student = await _db.Students.FirstOrDefaultAsync(t => t.StudentId == id);
                return Ok(student);
            } catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAllGrades"), Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<Grade>>> GetAllGrades()
        {
            try
            {
                var grade = await _db.Grades.ToListAsync();
                return Ok(grade);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        [HttpGet("GetAllSubjects"), Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<Subject>>> GetAllSubjects()
        {
            try
            {
                var subjects = await _db.Subjects.ToListAsync();
                return Ok(subjects);
            }
            catch (Exception ex) { return BadRequest(ex); }
        }
    }
}
