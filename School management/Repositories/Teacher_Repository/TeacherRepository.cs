using Microsoft.EntityFrameworkCore;
using School_management.Models;

namespace School_management.Repositories.Teacher_Repository
{
    public class TeacherRepository
    {
        public static async Task<Teacher> GetTeacherByNiNo(string NiNo)
        {
            var db = new SchoolManagementContext();
            var teacher = await db.Teachers.Where(x => x.NiNo == NiNo).FirstOrDefaultAsync();

            if (teacher == null)
            {
                throw new Exception("Invalid NiNo or Password");
            }

            return teacher;
        }
    }
}
