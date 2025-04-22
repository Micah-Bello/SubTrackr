using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SubTrackr.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    [HttpGet("secure")]
    [Authorize]
    public IActionResult SecureEndpoint()
    {
        return Ok(new
        {
            message = "🎉 You're authenticated!",
            user = User.Identity?.Name
        });
    }

    [HttpGet("public")]
    public IActionResult PublicEndpoint()
    {
        return Ok(new
        {
            message = "🌐 Anyone can access this."
        });
    }
}
