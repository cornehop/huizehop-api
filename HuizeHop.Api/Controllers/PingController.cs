using Microsoft.AspNetCore.Mvc;

namespace HuizeHop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PingController : ControllerBase
    {
        [HttpGet]
        public ActionResult Get()
        {
            return new OkResult();
        }
    }
}