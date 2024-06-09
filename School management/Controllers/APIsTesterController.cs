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

        //  Bearer eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTUxMiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJ1c2VyTmFtZSI6IkFsaTEyIiwiZXhwIjoxNzE3ODg0MTI2fQ.O6Hss-912ZybVD2vNdtvBmlpHJfUdQzNhEy4yMZkJLT3t6Xdu1iLn8gymmCIAdvmthCM56MpfXrxUceIZ3y8nw
        //  172737737
        [HttpPost("GetAllTeachers")]
        [Authorize()]
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
        [HttpGet("GetStudentById/{id}")]
        [Authorize()]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            try
            {
                var db = new SchoolManagementContext();
                Student student = await db.Students.FirstOrDefaultAsync(t => t.StudentId == id);
                return Ok(student);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
