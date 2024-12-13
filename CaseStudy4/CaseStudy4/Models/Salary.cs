using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

[Table("Salary")]
public partial class Salary
{
    [Key]
    [Column("SalaryId")]
    public int SalaryId { get; set; }

    public DateTime? SalaryCreatedDate {get; set;} = DateTime.Now;


    [Column(TypeName = "decimal(18, 2)")]
    public decimal? BasicSalary { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Allowances { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? Deductions { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? NetSalary { get; set; }

    [ForeignKey("SalaryId")]
    public virtual Employee? Employee { get; set; }
}
