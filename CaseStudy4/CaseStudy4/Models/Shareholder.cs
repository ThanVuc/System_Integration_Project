using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

[Table("Shareholder")]
public partial class Shareholder
{
    [Key]
    [Column("ShareholderID")]
    public int ShareholderId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? SharesOwned { get; set; }
}
