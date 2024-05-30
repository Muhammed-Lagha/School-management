using System;
using System.Collections.Generic;

namespace School_management.Model;

public partial class Student
{
    public int StudentId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public byte[]? ProfilePicture { get; set; }

    public int GradeId { get; set; }

    public virtual Grade Grade { get; set; } = null!;
}
