using CaseStudy4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Controllers
{
    [ApiController]
    [Route("api/dashboard")]
    public class DashBoardController : ControllerBase
    {
        private readonly HrandPayRollintegrationContext _context;

        public DashBoardController(HrandPayRollintegrationContext context)
        {
            _context = context;
        }

        [HttpGet("get-shareholder-earning")]
        public async Task<IActionResult> GetTotalEarningOfShareHolder()
        {
            var shareHolders = await _context.Shareholders
            .Include(sh => sh.Employee)
            .ToListAsync();

            var shareHoldersRes = new List<object>();

            decimal? total = 0;
            shareHolders.ForEach(s =>
            {
                shareHoldersRes.Add(new
                {
                    Name = s.Employee.FirstName + " " + s.Employee.LastName,
                    ShareHolderId = s.ShareholderId,
                    SharesOwned = s.SharesOwned
                });
                total += s.SharesOwned;
            });
            var apiRes = new
            {
                Total = total,
                ShareHolder = shareHoldersRes
            };
            return Ok(apiRes);
        }

        [HttpGet("get-synthetic-earning")]
        public async Task<IActionResult> GetSyntheticEarning()
        {
            var emps = await _context.Employees
            .ToListAsync();

            decimal? totalEarning = 0;
            decimal? totalBenefit = 0;

            foreach (var emp in emps)
            {
                totalEarning += emp.TotalEarning;
                totalBenefit += emp.AverageBenefits;
            }

            return Ok(new
            {
                TotalEarning = totalBenefit,
                Benefit = totalBenefit
            });

        }

        [HttpGet("get-department-earning")]
        public async Task<IActionResult> GetDepartmentEarning()
        {
            var departments = await _context.Departments
            .Include(d => d.Employees)
            .ToListAsync();

            var apiRes = new List<object>();

            foreach (var department in departments)
            {
                decimal? totalEarning = 0;
                foreach (var emp in department.Employees)
                {
                    totalEarning += emp.TotalEarning;
                }
                apiRes.Add(new
                {
                    DepartmentName = department.DepartmentName,
                    TotalEarning = totalEarning
                });
            }

            return Ok(apiRes);


        }

        [HttpGet("get-ethnicity-earning")]
        public async Task<IActionResult> GetEthnicityEarning()
        {
            var totalEthnicity = await _context.Employees
            .GroupBy(e => new {
                Ethnicity = e.Ethnicity,
            })
            .Select(e => new {
                Ethnicity = e.Key.Ethnicity,
                TotalEarning = e.Sum(e => e.TotalEarning)
            })
            .ToListAsync();

            return Ok(totalEthnicity);
        }

        [HttpGet("get-gender-earning")]
        public async Task<IActionResult> GetGenderEarning()
        {
            var totalEthnicity = await _context.Employees
            .GroupBy(e => new {
                Gender = e.Gender,
            })
            .Select(e => new {
                Gender = e.Key.Gender,
                TotalEarning = e.Sum(e => e.TotalEarning)
            })
            .ToListAsync();

            return Ok(totalEthnicity);
        }
        
        [HttpGet("get-worktime-earning")]
        public async Task<IActionResult> GetWorkTimeEarning()
        {
            var totalEthnicity = await _context.Employees
            .GroupBy(e => new {
                WorkTime = e.Fulltime,
            })
            .Select(e => new {
                WorkTime = e.Key.WorkTime,
                TotalEarning = e.Sum(e => e.TotalEarning)
            })
            .ToListAsync();

            return Ok(totalEthnicity);
        }

        [HttpGet("get-projects")]
        public async Task<IActionResult> GetProjects()
        {
            var totalEthnicity = await _context.Projects
            .Select(p => new {
                ProjectName  = p.ProjectName,
                Budget = p.Budget
            })
            .ToListAsync();

            return Ok(totalEthnicity);
        }
    }
}
