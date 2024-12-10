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
        public async Task<IActionResult> GetAllEmployees(){
            var employees = await _context.Employees
            .Include(e => e.Department)
            .Select(e => new {
                Id = e.EmployeeId,
                Name = e.FirstName + " " + e.LastName,
                Department = e.Department.DepartmentName,
                Gender = e.Gender,
                Ethinicity = e.Ethnicity,
                FullTime = e.Fulltime,
                TotalEarning = e.TotalEarning
             })
            .ToListAsync();

            return Ok(employees);

        }

    }
}