using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

public partial class LeaveDay
{
    [Key]
    [Column("LeaveID")]
    public int LeaveId { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    public DateOnly? LeaveDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? LeaveType { get; set; }

    public int? LeaveDuration { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("LeaveDays")]
    public virtual Employee? Employee { get; set; }
}
