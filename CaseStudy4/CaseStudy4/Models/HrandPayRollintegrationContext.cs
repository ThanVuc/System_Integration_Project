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
            entity.HasKey(e => e.SalaryId).HasName("PK__Salary__4BE204B7DD731782");

            entity.Property(e => e.SalaryId).ValueGeneratedNever();

            entity.HasOne(d => d.Employee).WithMany(p => p.Salaries).HasConstraintName("FK__Salary__Employee__60A75C0F");
        });

        modelBuilder.Entity<Shareholder>(entity =>
        {
            entity.HasKey(e => e.ShareholderId).HasName("PK__Sharehol__62752D90F3327882");

            entity.Property(e => e.ShareholderId).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
