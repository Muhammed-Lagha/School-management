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

        //  Bearer 
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
    }
}
