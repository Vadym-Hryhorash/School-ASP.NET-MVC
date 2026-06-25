using System;
using System.Collections.Generic;

namespace Lab2_Programming.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string Name { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? ThirdName { get; set; }

    public double? AverageGrade { get; set; }

    public int TeacherId { get; set; }

    public string? ParentsPhone { get; set; }

    public virtual Teacher Teacher { get; set; } = null!;
}
