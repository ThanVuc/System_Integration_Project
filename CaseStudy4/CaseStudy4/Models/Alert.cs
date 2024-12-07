using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

public partial class Alert
{
    [Key]
    [Column("AlertID")]
    public int AlertId { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AlertType { get; set; }

    public DateOnly? AlertDate { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? AlertStatus { get; set; }

    [Column("EmployeeID")]
    public int? EmployeeId { get; set; }

    [ForeignKey("EmployeeId")]
    [InverseProperty("Alerts")]
    public virtual Employee? Employee { get; set; }
}
