using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

public partial class Benefit
{
    [Key]
    [Column("BenefitID")]
    public int BenefitId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BenefitType { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? BenefitAmount { get; set; }

    public DateOnly? EffectiveDate { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Benefits")]
    public virtual Employee? Employee { get; set; }
}
