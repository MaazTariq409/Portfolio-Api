using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Portfolio_API.Data;
using Portfolio_API.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Portfolio_API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PorfolioContext _context;
        private readonly IConfiguration _configuration;

        public AuthController(PorfolioContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        [HttpPost]
        public ActionResult<string> userAuthentication(SignIn signIn)
        {
            var user = validateUserInput(signIn.Email, signIn.Password);

            if(user == null)
            {
                return Unauthorized();
            }

            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));

            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var TokenClaims = new List<Claim>();
            TokenClaims.Add(new Claim("UserId", user.Id.ToString()));
            TokenClaims.Add(new Claim("UserName", user.Username.ToString()));
            TokenClaims.Add(new Claim("Email", user.Email.ToString()));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["authentication:Audiance"],
                TokenClaims,
                DateTime.Now,
                DateTime.Now.AddHours(1),
                signingCredentials
                );

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return Ok(tokenToReturn);
        }

        private User validateUserInput(string email, string password)
        {
            var validUser = _context.user.FirstOrDefault(x => x.Email == email && x.Password == password);
            if (validUser == null)
            {
                return null;
            }
            return validUser;
        }
    }
}
