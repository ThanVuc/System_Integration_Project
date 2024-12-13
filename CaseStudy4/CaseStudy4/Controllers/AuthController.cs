using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CaseStudy4.DTO;
using CaseStudy4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]LoginRequestModel loginRequestModel)
        {
            if (loginRequestModel is null)
            {
                return BadRequest("Invalid client request");
            }

            var user = await _context.Employees
            .FirstOrDefaultAsync(e => e.Username == loginRequestModel.Username && e.PasswordHash == loginRequestModel.Password);

            if (user != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSdaklsdjkljaafisdfopi234lkjlkjdfkljdflkjecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:5003",
                    audience: "https://localhost:5003",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }
    }

    internal class AuthenticatedResponse
    {
        public string? Token { get; set; }
    }
}
