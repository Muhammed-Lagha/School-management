using System;
using System.Collections.Generic;

namespace School_management.Model;

public partial class Subject
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int GradeNumber { get; set; }

    public int GradeId { get; set; }

    public virtual Grade Grade { get; set; } = null!;

    public virtual ICollection<Timetable> TimetablePeriod1Subjects { get; set; } = new List<Timetable>();

    public virtual ICollection<Timetable> TimetablePeriod2Subjects { get; set; } = new List<Timetable>();

    public virtual ICollection<Timetable> TimetablePeriod3Subjects { get; set; } = new List<Timetable>();

    public virtual ICollection<Timetable> TimetablePeriod4Subjects { get; set; } = new List<Timetable>();

    public virtual ICollection<Timetable> TimetablePeriod5Subjects { get; set; } = new List<Timetable>();

    public virtual ICollection<Timetable> TimetablePeriod6Subjects { get; set; } = new List<Timetable>();
}
