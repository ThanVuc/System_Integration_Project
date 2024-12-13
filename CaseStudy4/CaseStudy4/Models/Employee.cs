using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [Required]
    public string? Username { get; set; }
    [Required]
    public string? PasswordHash { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? FirstName { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? LastName { get; set; }

    [StringLength(10)]
    [Unicode(false)]
    public string? Gender { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Ethnicity { get; set; }

    public DateOnly? HireDate { get; set; }

    [Column("DepartmentID")]
    public int? DepartmentId { get; set; }

    [Column("BranchID")]
    public int? BranchId { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? TotalEarning { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Address { get; set; }

    [StringLength(1)]
    [Unicode(false)]
    public string? Fulltime { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal? AverageBenefits { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string? Phone { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("PositionID")]
    public int? PositionId { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<Alert> Alerts { get; set; } = new List<Alert>();

    [InverseProperty("Employee")]
    public virtual ICollection<Attendance> Attendances { get; set; } = new List<Attendance>();

    [InverseProperty("Employee")]
    public virtual ICollection<Benefit> Benefits { get; set; } = new List<Benefit>();

    [InverseProperty("Employee")]
    public virtual ICollection<DayOff> DayOffs { get; set; } = new List<DayOff>();

    [ForeignKey("DepartmentId")]
    [InverseProperty("Employees")]
    public virtual Department? Department { get; set; }

    [InverseProperty("Employee")]
    public virtual ICollection<LeaveDay> LeaveDays { get; set; } = new List<LeaveDay>();

    [InverseProperty("Employee")]
    public virtual ICollection<Payroll> Payrolls { get; set; } = new List<Payroll>();

    [ForeignKey("PositionId")]
    [InverseProperty("Employees")]
    public virtual Position? Position { get; set; }
    
    public virtual Salary? Salary { get; set; }
}
