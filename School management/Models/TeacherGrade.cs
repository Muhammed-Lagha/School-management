using System;
using System.Collections.Generic;

namespace School_management.Models;

public partial class TeacherGrade
{
    public int Id { get; set; }

    public int GradeId { get; set; }

    public int TeacherId { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual Teacher Teacher { get; set; } = null!;
}
