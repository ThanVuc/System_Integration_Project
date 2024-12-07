using CaseStudy4.DTO;
using CaseStudy4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy4.Controllers
{
    [ApiController]
    [Route("/api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly HrandPayRollintegrationContext _context;
        public AuthController(HrandPayRollintegrationContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel loginRequest)
        {
            if (loginRequest == null)
            {
                return BadRequest("Login information is not exist");
            }

            var user = await _context.Employees.FirstOrDefaultAsync(e => e.Username == loginRequest.Username && e.PasswordHash == loginRequest.Password);
            
            if (user == null)
            {
                return BadRequest("Username or Password is incorrect");
            }

            return Ok("Login Success");
        }
    }
}
