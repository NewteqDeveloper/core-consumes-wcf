using CoreWebApi.Controllers.Base;
using Microsoft.AspNetCore.Mvc;
using SampleWcfService;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    public class WcfController : ApiBaseController
    {
        [HttpGet]
        [Route("hello")]
        public IActionResult HelloWorld()
        {
            return Ok("hello world");
        }

        [HttpGet]
        [Route("echo")]
        public async Task<IActionResult> Echo(string input)
        {
            var wcfClient = new WcfServiceClient();
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                input = "nothing set";
            }

            var output = "An error has occured \r\n";

            try
            {
                output = await wcfClient.EchoAsync(input);
            }
            catch (CommunicationException commsException)
            {
                #if DEBUG
                output += $"The service is unreachable. The error from the exception is: {commsException.Message}";
                #else
                output += $"The service is unreachable.";
                #endif
            }
            catch(Exception e)
            {
                #if DEBUG
                output += $"Some unexpected exception occured. The error message is: {e.Message}\r\n\r\n The stacktrace is:\r\n{e.StackTrace}";
                #else
                output += $"Some unexpected exception occured.";
                #endif
            }
            return Ok(output);
        }
    }
}
