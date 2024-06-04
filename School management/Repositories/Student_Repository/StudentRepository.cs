using Microsoft.EntityFrameworkCore;
using School_management.Models;

namespace School_management.Repositories.Student_Repository
{
    public class StudentRepository
    {
        public static async Task<Student> GetStudentByName(string name)
        {
            var db = new SchoolManagementContext();
            var student = await db.Students.Where(x => x.FirstName == name).FirstOrDefaultAsync();
            if (student == null)
            {
                throw new Exception("Invalid Name or Password");
            }
            return student;
        }
    }
}
