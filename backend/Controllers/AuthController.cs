using backend.Services.UserServices;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _auth;

        public AuthController(IAuthService auth)
        {
            _auth = auth;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] DTOs.UserDros.LoginRequest request)
        {
            var response = await _auth.AuthenticateAsync(request);
            if (response == null)
                return Unauthorized("Invalid credentials.");
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] DTOs.UserDros.RegisterRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.Role) ||
                !new[] { "Student", "Teacher","Admin" }.Contains(request.Role))
            {
                return BadRequest(new { message = "Role must be 'Student' or 'Teacher'." });
            }

            var success = await _auth.RegisterAsync(request.Username, request.Password, request.Role);
            if (!success)
                return Conflict(new { message = "Username already exists." });

            return Ok(new { message = "User registered successfully." });
        }

    }
}
