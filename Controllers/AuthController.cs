using Microsoft.AspNetCore.Mvc;
using Portfolio_API.Data;
using Portfolio_API.Models;

namespace Portfolio_API.Controllers
{
    [Route("api/Auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly PorfolioContext _context;
        private readonly IConfiguration _configuration;
        private readonly TokenGeneration _token;

        public AuthController(PorfolioContext context, IConfiguration configuration, TokenGeneration token)
        {
            _context = context;
            _configuration = configuration;
            _token = token;
        }

        [HttpPost]
        public ActionResult<string> userAuthentication(SignIn signIn)
        {
            var user = _token.validateUserInput(signIn.Email, signIn.Password);

            if(user == null)
            {
                return Unauthorized();
            }

            var tokenToReturn = _token.TokenGenerator(user);

            return Ok(tokenToReturn);
        }
    }
}
