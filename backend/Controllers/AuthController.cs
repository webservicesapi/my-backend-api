using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{
    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request.Email == "test@example.com" && request.Password == "123456")
        {
            return Ok(new { token = "test-jwt-token" });
        }

        return Unauthorized();
    }
}
public class LoginRequest
{
    public string Email { get; set; }
    public string Password { get; set; }
}

