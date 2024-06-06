using Microsoft.EntityFrameworkCore;
using School_management.Models;

namespace School_management.Repositories.Teacher_Repository
{
    public class TeacherRepository
    {
        public static async Task<Teacher> GetTeacherByUserName(string userName)
        {
            var db = new SchoolManagementContext();
            var teacher = await db.Teachers.Where(x => x.Username == userName).FirstOrDefaultAsync();

            if (teacher == null)
            {
                throw new Exception("Invalid UserName or Password");
            }

            return teacher;
        }
    }
}
