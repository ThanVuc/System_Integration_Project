using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

[Table("Attendance")]
public partial class Attendance
{
    [Key]
    [Column("AttendanceID")]
    public int AttendanceId { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    public DateOnly? Date { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Attendances")]
    public virtual Employee? Employee { get; set; }
}
