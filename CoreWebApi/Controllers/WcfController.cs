using CoreWebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers
{
    public class WcfController : ApiBaseController
    {
        [HttpGet]
        [Route("echo")]
        public IActionResult Echo()
        {
            return Ok("hello world");
        }
    }
}
