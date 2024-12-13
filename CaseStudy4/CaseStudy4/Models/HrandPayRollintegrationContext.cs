using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Models;

public partial class HrandPayRollintegrationContext : DbContext
{
    public HrandPayRollintegrationContext()
    {
    }

    public HrandPayRollintegrationContext(DbContextOptions<HrandPayRollintegrationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Alert> Alerts { get; set; }

    public virtual DbSet<Attendance> Attendances { get; set; }

    public virtual DbSet<Benefit> Benefits { get; set; }

    public virtual DbSet<Branch> Branches { get; set; }

    public virtual DbSet<DayOff> DayOffs { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<LeaveDay> LeaveDays { get; set; }

    public virtual DbSet<Location> Locations { get; set; }

    public virtual DbSet<Payroll> Payrolls { get; set; }

    public virtual DbSet<PerformanceReview> PerformanceReviews { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Salary> Salaries { get; set; }

    public virtual DbSet<Shareholder> Shareholders { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<Alert>(entity =>
        {
            entity.HasKey(e => e.AlertId).HasName("PK__Alerts__EBB16AED1FC1AFC6");

            entity.Property(e => e.AlertId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.Alerts).HasConstraintName("FK__Alerts__Employee__628FA481");
        });

        modelBuilder.Entity<Attendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__Attendan__8B69263CE0FD4BA2");

            entity.Property(e => e.AttendanceId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.Attendances).HasConstraintName("FK__Attendanc__Emplo__6383C8BA");
        });

        modelBuilder.Entity<Benefit>(entity =>
        {
            entity.HasKey(e => e.BenefitId).HasName("PK__Benefits__5754C53A49CF8E9E");

            entity.Property(e => e.BenefitId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.Benefits).HasConstraintName("FK__Benefits__Employ__5FB337D6");
        });

        modelBuilder.Entity<Branch>(entity =>
        {
            entity.HasKey(e => e.BranchId).HasName("PK__Branch__A1682FA52FDE8880");

            entity.Property(e => e.BranchId).ValueGeneratedNever();

            entity.HasOne(d => d.Location).WithMany(p => p.Branches).HasConstraintName("FK__Branch__Location__398D8EEE");
        });

        modelBuilder.Entity<DayOff>(entity =>
        {
            entity.HasKey(e => e.DayOffId).HasName("PK__DayOff__8A0FE594E21B2CCE");

            entity.Property(e => e.DayOffId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.DayOffs).HasConstraintName("FK__DayOff__Employee__5AEE82B9");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BCD9FB255E0");

            entity.Property(e => e.DepartmentId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04FF19430E508");

            entity.Property(e => e.EmployeeId).ValueGeneratedNever();
            entity.Property(e => e.Fulltime).IsFixedLength();

            entity.HasOne(d => d.Department).WithMany(p => p.Employees).HasConstraintName("FK__Employees__Depar__571DF1D5");

            entity.HasOne(d => d.Position).WithMany(p => p.Employees).HasConstraintName("FK__Employees__Posit__5629CD9C");
        });

        modelBuilder.Entity<LeaveDay>(entity =>
        {
            entity.HasKey(e => e.LeaveId).HasName("PK__LeaveDay__796DB9793457280D");

            entity.Property(e => e.LeaveId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.LeaveDays).HasConstraintName("FK__LeaveDays__Emplo__59FA5E80");
        });

        modelBuilder.Entity<Location>(entity =>
        {
            entity.HasKey(e => e.LocationId).HasName("PK__Location__E7FEA4772940CB3F");

            entity.Property(e => e.LocationId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Payroll>(entity =>
        {
            entity.HasKey(e => e.PayrollId).HasName("PK__Payroll__99DFC692F7A754CD");

            entity.Property(e => e.PayrollId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.Payrolls).HasConstraintName("FK__Payroll__Employe__5DCAEF64");
        });

        modelBuilder.Entity<PerformanceReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId).HasName("PK__Performa__74BC79AEED069A6B");

            entity.Property(e => e.ReviewId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PositionId).HasName("PK__Position__60BB9A59B6575289");

            entity.Property(e => e.PositionId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.ProjectId).HasName("PK__Projects__761ABED00381FBBC");

            entity.Property(e => e.ProjectId).ValueGeneratedNever();
        });

        modelBuilder.Entity<Salary>(entity =>
        {
            entity.HasKey(e => e.SalaryId).HasName("PK__Salary__4BE204B7DD731782A");

            entity.Property(e => e.SalaryId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithOne(p => p.Salary).HasConstraintName("FK__Salary__Employee__60A75C0F");
        });

        modelBuilder.Entity<Shareholder>(entity =>
        {
            entity.HasKey(e => e.ShareholderId).HasName("PK__Sharehol__62752D90F3327882");

            entity.Property(e => e.ShareholderId).ValueGeneratedNever();
        });


       // Seed Data for Employees
        modelBuilder.Entity<Employee>().HasData(
        new Employee
        {
            EmployeeId = 1,
            Username = "johndoe@example.com", // Using email as username
            PasswordHash = "hash1",
            FirstName = "John",
            LastName = "Doe",
            Gender = "Male",
            DateOfBirth = DateOnly.FromDateTime(new DateTime(1990, 1, 15)),
            Ethnicity = "China",
            HireDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-5)),
            DepartmentId = 1,
            BranchId = 1,
            TotalEarning = 100000,
            Address = "123 Main St",
            Fulltime = "P",
            AverageBenefits = 5000,
            Phone = "123-456-7890",
            Email = "johndoe@example.com",
            PositionId = 1
        },
        new Employee
        {
            EmployeeId = 2,
            Username = "alicesmith@example.com", // Using email as username
            PasswordHash = "hash2",
            FirstName = "Alice",
            LastName = "Smith",
            Gender = "Female",
            DateOfBirth = DateOnly.FromDateTime(new DateTime(1992, 5, 22)),
            Ethnicity = "America",
            HireDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-3)),
            DepartmentId = 2,
            BranchId = 2,
            TotalEarning = 80000,
            Address = "456 Elm St",
            Fulltime = "F",
            AverageBenefits = 3000,
            Phone = "987-654-3210",
            Email = "alicesmith@example.com",
            PositionId = 2
        },
        new Employee
        {
            EmployeeId = 3,
            Username = "brucewayne@example.com", // Using email as username
            PasswordHash = "hash3",
            FirstName = "Bruce",
            LastName = "Wayne",
            Gender = "Male",
            DateOfBirth = DateOnly.FromDateTime(new DateTime(1985, 11, 17)),
            Ethnicity = "America",
            HireDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
            DepartmentId = 3,
            BranchId = 3,
            TotalEarning = 75000,
            Address = "789 Oak St",
            Fulltime = "F",
            AverageBenefits = 4000,
            Phone = "555-555-5555",
            Email = "brucewayne@example.com",
            PositionId = 3
        },
        new Employee
        {
            EmployeeId = 4,
            Username = "sinh@gmail.com", // Using email as username
            PasswordHash = "123",
            FirstName = "Sinh",
            LastName = "Nguyen",
            Gender = "Male",
            DateOfBirth = DateOnly.FromDateTime(new DateTime(1985, 11, 17)),
            Ethnicity = "Viet Nam",
            HireDate = DateOnly.FromDateTime(DateTime.Now.AddYears(-10)),
            DepartmentId = 3,
            BranchId = 3,
            TotalEarning = 75000,
            Address = "789 Oak St",
            Fulltime = "F",
            AverageBenefits = 4000,
            Phone = "555-555-5555",
            Email = "brucewayne@example.com",
            PositionId = 3
        }
    );

        // Seed Data for Departments
        modelBuilder.Entity<Department>().HasData(
            new Department { DepartmentId = 1, DepartmentName = "IT" },
            new Department { DepartmentId = 2, DepartmentName = "HR" },
            new Department { DepartmentId = 3, DepartmentName = "Finance" }
        );

        // Seed Data for Branches
        modelBuilder.Entity<Branch>().HasData(
            new Branch { BranchId = 1, BranchName = "Headquarters", BranchManager = "John Manager" },
            new Branch { BranchId = 2, BranchName = "East Office", BranchManager = "Alice Manager" },
            new Branch { BranchId = 3, BranchName = "West Office", BranchManager = "Bruce Manager" }
        );

        // Seed Data for Positions
        modelBuilder.Entity<Position>().HasData(
            new Position { PositionId = 1, PositionName = "Manager", BasicSalary = 100000 },
            new Position { PositionId = 2, PositionName = "Developer", BasicSalary = 80000 },
            new Position { PositionId = 3, PositionName = "Analyst", BasicSalary = 75000 }
        );

        // Seed Data for Salaries
        modelBuilder.Entity<Salary>().HasData(
            new Salary { SalaryId = 1, BasicSalary = 100000, Allowances = 5000, Deductions = 2000, NetSalary = 103000 },
            new Salary { SalaryId = 2, BasicSalary = 80000, Allowances = 3000, Deductions = 1000, NetSalary = 82000 },
            new Salary { SalaryId = 3, BasicSalary = 75000, Allowances = 4000, Deductions = 1500, NetSalary = 78500 }
        );

        // Seed Data for Projects
        modelBuilder.Entity<Project>().HasData(
            new Project { ProjectId = 1, ProjectName = "Project A", StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-6)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(6)) },
            new Project { ProjectId = 2, ProjectName = "Project B", StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-12)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)) },
            new Project { ProjectId = 3, ProjectName = "Project C", StartDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-3)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(9)) }
        );

        // Seed Data for Attendance
        modelBuilder.Entity<Attendance>().HasData(
            new Attendance { AttendanceId = 1, EmployeeId = 1, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), Status = "Present" },
            new Attendance { AttendanceId = 2, EmployeeId = 2, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), Status = "Absent" },
            new Attendance { AttendanceId = 3, EmployeeId = 3, Date = DateOnly.FromDateTime(DateTime.Now.AddDays(-1)), Status = "Present" }
        );

        // Seed Data for DaysOff
        modelBuilder.Entity<DayOff>().HasData(
            new DayOff { DayOffId = 1, EmployeeId = 1, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-7)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-5)), Hours = 16, Status = "Approved" },
            new DayOff { DayOffId = 2, EmployeeId = 2, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-10)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-9)), Hours = 8, Status = "Pending" },
            new DayOff { DayOffId = 3, EmployeeId = 3, StartDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-20)), EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-18)), Hours = 24, Status = "Rejected" }
        );

        // Seed Data for LeaveDays
        modelBuilder.Entity<LeaveDay>().HasData(
            new LeaveDay { LeaveId = 1 ,EmployeeId = 1, LeaveDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-30)), LeaveType = "Sick Leave", LeaveDuration = 8 },
            new LeaveDay { LeaveId = 2 ,EmployeeId = 2, LeaveDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-60)), LeaveType = "Annual Leave", LeaveDuration = 16 },
            new LeaveDay { LeaveId = 3 ,EmployeeId = 3, LeaveDate = DateOnly.FromDateTime(DateTime.Now.AddDays(-15)), LeaveType = "Maternity Leave", LeaveDuration = 40 }
        );

        // Seed Data for Benefits
        modelBuilder.Entity<Benefit>().HasData(
            new Benefit { BenefitId = 1, BenefitType = "Health Insurance", BenefitAmount = 5000, EffectiveDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-12)) },
            new Benefit { BenefitId = 2, BenefitType = "Retirement Fund", BenefitAmount = 8000, EffectiveDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-6)) },
            new Benefit { BenefitId = 3, BenefitType = "Travel Allowance", BenefitAmount = 3000, EffectiveDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-18)) }
        );

        // Seed Data for Payrolls
        modelBuilder.Entity<Payroll>().HasData(
            new Payroll { PayrollId = 1, EmployeeId = 1, PayDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)) },
            new Payroll { PayrollId = 2, EmployeeId = 2, PayDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-2)) },
            new Payroll { PayrollId = 3, EmployeeId = 3, PayDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-3)) }
        );

        // Seed Data for PerformanceReviews
        modelBuilder.Entity<PerformanceReview>().HasData(
            new PerformanceReview { ReviewId = 1, ReviewDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-12)), Reviewer = "Manager A", Score = 90 },
            new PerformanceReview { ReviewId = 2, ReviewDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-6)), Reviewer = "Manager B", Score = 85 },
            new PerformanceReview { ReviewId = 3, ReviewDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-9)), Reviewer = "Manager C", Score = 88 }
        );

        // Seed Data for Alerts
        modelBuilder.Entity<Alert>().HasData(
            new Alert { AlertId = 1, AlertType = "System Maintenance", AlertDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-1)), AlertStatus = "Resolved" },
            new Alert { AlertId = 2, AlertType = "Policy Update", AlertDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-2)), AlertStatus = "Pending" },
            new Alert { AlertId = 3, AlertType = "Security Breach", AlertDate = DateOnly.FromDateTime(DateTime.Now.AddMonths(-3)), AlertStatus = "Resolved" }
        );

        // Seed Data for Shareholders
        modelBuilder.Entity<Shareholder>().HasData(
            new Shareholder { ShareholderId = 1, SharesOwned = 50 },
            new Shareholder { ShareholderId = 2, SharesOwned = 30 },
            new Shareholder { ShareholderId = 3, SharesOwned = 20 }
        );

        // Seed Data for Locations
        modelBuilder.Entity<Location>().HasData(
            new Location { LocationId = 1, StreetAddress = "123 Main St", Postcode = "12345", City = "Metropolis" },
            new Location { LocationId = 2, StreetAddress = "456 Elm St", Postcode = "67890", City = "Gotham" },
            new Location { LocationId = 3, StreetAddress = "789 Oak St", Postcode = "54321", City = "Star City" }
        );


        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
