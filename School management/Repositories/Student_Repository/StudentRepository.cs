using Microsoft.EntityFrameworkCore;
using School_management.Models;

namespace School_management.Repositories.Student_Repository
{
    public class StudentRepository
    {
        public static async Task<Student> GetStudentByUserName(string Username)
        {
            var db = new SchoolManagementContext();
            var student = await db.Students.Where(t => t.Username == Username).FirstOrDefaultAsync();
            if (student == null)
            {
                throw new Exception("Invalid UserName or Password");
            }
            return student;
        }
    }
}
