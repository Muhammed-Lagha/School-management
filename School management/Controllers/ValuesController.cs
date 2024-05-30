using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School_management.Models;
using System.Security.Claims;

namespace School_management.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        [HttpPost("ess")]

        public async Task<ActionResult<List<Teacher>>> ess()
        {
            try
            {
                var db = new SchoolManagementContext();

                List<Teacher> teacher = await db.Teachers.Where(t => t.Id == 2).ToListAsync();
                return Ok(teacher);
            }
            catch (Exception ex)
            {
               
                return BadRequest(null);
            }
        }
    }
}
