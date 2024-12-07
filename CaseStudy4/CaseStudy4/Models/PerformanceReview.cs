using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

public partial class PerformanceReview
{
    [Key]
    [Column("ReviewID")]
    public int ReviewId { get; set; }

    public DateOnly? ReviewDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Reviewer { get; set; }

    public double? Score { get; set; }

    [StringLength(255)]
    [Unicode(false)]
    public string? Comments { get; set; }
}
