using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIFinal.Controllers
{
    [ApiController]
    public class IndexController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public ActionResult GetAllAsync()
        {
            return Ok(new { status = "Ok" });
        }
    }
}
