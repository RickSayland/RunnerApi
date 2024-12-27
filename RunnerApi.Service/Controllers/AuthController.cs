using RunnerApi.Service.Services;

namespace RunnerApi.Service.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IJwtAuthManager _jwtAuthManager;

    public AuthController(IJwtAuthManager jwtAuthManager)
    {
        _jwtAuthManager = jwtAuthManager;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // For simplicity, hardcode a single username/password combination
        if (request.Username == "admin" && request.Password == "password")
        {
            var token = _jwtAuthManager.GenerateToken(request.Username);
            return Ok(new { Token = token });
        }

        return Unauthorized();
    }
}

public class LoginRequest
{
    public string Username { get; set; }
    public string Password { get; set; }
}
