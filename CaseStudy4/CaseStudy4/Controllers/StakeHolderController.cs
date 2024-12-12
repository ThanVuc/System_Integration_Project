using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaseStudy4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Controllers
{
    [ApiController]
    [Route("api/stake-holder-employees")]
    public class StakeHolderController : ControllerBase
    {
        private readonly HrandPayRollintegrationContext _context;
        public StakeHolderController(HrandPayRollintegrationContext context)
        {
            _context = context;
        }

        [HttpGet("employees")]
        public async Task<IActionResult> GetAllEmployees([FromQuery] string? filter){
            var employees = _context.Employees
            .Include(e => e.Department)
            .Select(e => new {
                Id = e.EmployeeId,
                Name = e.FirstName + " " + e.LastName,
                Department = e.Department.DepartmentName,
                Gender = e.Gender,
                Ethinicity = e.Ethnicity,
                FullTime = e.Fulltime,
                TotalEarning = e.TotalEarning
             });

            if (filter != null){
                employees = employees.Where(e => e.Department == filter);
            }

            var employeesRes = await employees.ToListAsync();

            return Ok(employeesRes);
        }

        [HttpGet("employees/{id:int}")]
        public async Task<IActionResult> GetEmloyeeDetail([FromRoute] int id){
            
            var leaveDateOfEmp = await _context.Employees
            .Include(e => e.LeaveDays)
            .Select(e => e.LeaveDays.Select(l => l.LeaveDate))
            .FirstOrDefaultAsync();
            
            var leaveDate = new List<DateOnly?>();

            foreach (var ld in leaveDateOfEmp){
                var today = DateTime.Now;
                DateOnly startOfMonth = new DateOnly(today.Year, today.Month,1);

                if (ld > startOfMonth){
                    leaveDate.Add(ld);
                }
            }
            
            var employee = await _context.Employees
            .Include(e => e.Department)
            .Include(e => e.Position)
            .Select(e => new {
                Id = e.EmployeeId,
                Name = e.FirstName + " " + e.LastName,
                Department = e.Department.DepartmentName,
                Gender = e.Gender,
                Ethinicity = e.Ethnicity,
                FullTime = e.Fulltime,
                Position = e.Position.PositionName,
                LeaveDay = leaveDate,
                Join = e.HireDate,
                Mail = e.Email,
                Phone = e.Phone,
                Birth = e.DateOfBirth,
                Address = e.Address
             })
            .FirstOrDefaultAsync(e => e.Id == id);


            return Ok(employee);
        }

    }
}