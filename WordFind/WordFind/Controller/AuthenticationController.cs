using Microsoft.AspNetCore.Mvc;
using WordFind.Model;
using WordFind.Interface;
namespace WordFind.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;

        public AuthenticationController(IAuthenticationServices authenticationService)
        {
            _authenticationService = authenticationService;
        }

        [HttpPost("register")]
        public ActionResult<string> Register([FromBody] UserRegistrationRequest request)
        {
            if (!_authenticationService.isUserIdAvailable(request.userId))
            {
                return Conflict("User ID already exists");
            }

            _authenticationService.registerUser(request.userId, request.password);
            return Ok("User registered successfully");
        }

        [HttpPost("login")]
        public ActionResult<string> Login([FromBody] UserLoginRequest request)
        {
            string authToken = _authenticationService.authenticateUser(request.userId, request.password);
            if (authToken == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok(authToken);
        }
    }
}
