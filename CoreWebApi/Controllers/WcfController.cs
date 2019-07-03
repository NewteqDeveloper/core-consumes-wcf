using CoreWebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace CoreWebApi.Controllers
{
    public class WcfController : ApiBaseController
    {
        [HttpGet]
        public IActionResult EchoWcf()
        {
            return Ok("hello world");
        }
    }
}
