using Microsoft.AspNetCore.Mvc;

namespace HuizeHop.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class PingController : ControllerBase
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }
}