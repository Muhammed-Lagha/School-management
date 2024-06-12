using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_management.Models;

namespace School_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class APIsTesterController : ControllerBase
    {

        //  Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjgiLCJ1c2VyTmFtZSI6IkFsbGFkYWEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJUZWFjaGVyIiwiZXhwIjoxNzE4MTQ0MzE4fQ.yyESwFev_I6Z9v1z8PQf27YyxYSFFbcxCUXx4M4AeJADtspTcD1VeZopYaWSgODScvtrpqxHFWhsEl7GErGsrw
        //  172737737
        [HttpPost("GetAllTeachers"), Authorize(Roles = "Teacher")]
        
        public async Task<ActionResult<List<Teacher>>> GetAllTeachers()
        {
            try
            {
                var db = new SchoolManagementContext();

                List<Teacher> teacher = await db.Teachers.ToListAsync();
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
                var db = new SchoolManagementContext();

                List<Student> students = await db.Students.ToListAsync();
                return Ok(students);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
        [HttpGet("GetStudentById/{id}") , Authorize(Roles = "Teacher")]
        [Authorize()]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            try
            {
                var db = new SchoolManagementContext();
                //if (id == null) return BadRequest("");

                var student = await db.Students.FirstOrDefaultAsync(t => t.StudentId == id);
                return Ok(student);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("GetAllGrades") ,Authorize(Roles = "Teacher")]
        public async Task<ActionResult<List<Grade>>> GetAllGrades()
        {
            try
            {
                var db = new SchoolManagementContext();
                var grade = await db.Grades.ToListAsync();
                return Ok(grade);
            }
            catch(Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
    }
}
