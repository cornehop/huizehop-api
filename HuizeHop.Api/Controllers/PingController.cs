using Microsoft.AspNetCore.Mvc;

namespace HuizeHop.Api.Controllers;

public class PingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}