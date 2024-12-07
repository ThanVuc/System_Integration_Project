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
            var shareHolders = await _context.Shareholders.ToListAsync();
            decimal? total = 0;
            shareHolders.ForEach(s => total += s.SharesOwned);
            var apiRes = new
            {
                Total = total,
                ShareHolder = shareHolders
            };
            return Ok(apiRes);
        }
    }
}
