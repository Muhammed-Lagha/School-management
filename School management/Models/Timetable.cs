using System;
using System.Collections.Generic;

namespace School_management.Models;

public partial class Timetable
{
    public int Id { get; set; }

    public int DayOfWeek { get; set; }

    public int Period1SubjectId { get; set; }

    public int Period2SubjectId { get; set; }

    public int Period3SubjectId { get; set; }

    public int Period4SubjectId { get; set; }

    public int Period5SubjectId { get; set; }

    public int Period6SubjectId { get; set; }

    public virtual Subject Period1Subject { get; set; } = null!;

    public virtual Subject Period2Subject { get; set; } = null!;

    public virtual Subject Period3Subject { get; set; } = null!;

    public virtual Subject Period4Subject { get; set; } = null!;

    public virtual Subject Period5Subject { get; set; } = null!;

    public virtual Subject Period6Subject { get; set; } = null!;
}
