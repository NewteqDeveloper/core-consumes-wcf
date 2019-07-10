using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers.Base
{
    [Route("[controller]")]
    [ApiController]
    [EnableCors]
    public class ApiBaseController : ControllerBase
    {
    }
}
