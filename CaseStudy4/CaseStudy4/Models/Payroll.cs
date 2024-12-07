using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

[Table("Payroll")]
public partial class Payroll
{
    [Key]
    [Column("PayrollID")]
    public int PayrollId { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    public DateOnly? PayDate { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Payrolls")]
    public virtual Employee? Employee { get; set; }
}
