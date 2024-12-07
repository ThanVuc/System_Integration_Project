using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

[Table("Branch")]
public partial class Branch
{
    [Key]
    [Column("BranchID")]
    public int BranchId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchName { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? BranchManager { get; set; }

    [Column("LocationID")]
    public int? LocationId { get; set; }

    [ForeignKey("LocationId")]
    [InverseProperty("Branches")]
    public virtual Location? Location { get; set; }
}
