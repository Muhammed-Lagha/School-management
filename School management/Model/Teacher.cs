using System;
using System.Collections.Generic;

namespace School_management.Model;

public partial class Teacher
{
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string NiNo { get; set; } = null!;

    public byte[]? ProfilePicture { get; set; }

    public DateOnly BirthDate { get; set; }

    public virtual ICollection<TeacherGrade> TeacherGrades { get; set; } = new List<TeacherGrade>();
}
