using System;
using System.Collections.Generic;

namespace School_management.Models;

public partial class Grade
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int GradeNumber { get; set; }

    public virtual ICollection<Student> Students { get; set; } = new List<Student>();

    public virtual ICollection<Subject> Subjects { get; set; } = new List<Subject>();

    public virtual ICollection<TeacherGrade> TeacherGrades { get; set; } = new List<TeacherGrade>();
}
