using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

public partial class Location
{
    [Key]
    [Column("LocationID")]
    public int LocationId { get; set; }

    [StringLength(100)]
    [Unicode(false)]
    public string? StreetAddress { get; set; }

    [StringLength(8)]
    [Unicode(false)]
    public string? Postcode { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? City { get; set; }

    [InverseProperty("Location")]
    public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();
}
