using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

[Table("DayOff")]
public partial class DayOff
{
    [Key]
    [Column("DayOffID")]
    public int DayOffId { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    public DateOnly? StartDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public int? Hours { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Status { get; set; }

    [Column("ApprovedID")]
    public int? ApprovedId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("DayOffs")]
    public virtual Employee? Employee { get; set; }
}
