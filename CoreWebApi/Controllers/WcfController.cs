﻿using CoreWebApi.Controllers.Base;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SampleFrameworkWcf;
using System;
using System.ServiceModel;
using System.Threading.Tasks;

namespace CoreWebApi.Controllers
{
    public class WcfController : ApiBaseController
    {
        public IHostingEnvironment Environment { get; }

        public WcfController(IHostingEnvironment environment)
        {
            Environment = environment;
        }

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
            var wcfClient = new SampleWcfClient();
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                input = "nothing set";
            }

            var output = "An error has occured \r\n";

            try
            {
                output = await wcfClient.EchoXmlAsync(input);
            }
            catch (CommunicationException commsException)
            {
                if (Environment.IsDevelopment())
                {
                    output += $"The service is unreachable. The error from the exception is: {commsException.Message}";
                }
                else
                {
                    output += $"The service is unreachable.";
                }
            }
            catch(Exception e)
            {
                if (Environment.IsDevelopment())
                {
                    output += $"Some unexpected exception occured. The error message is: {e.Message}\r\n\r\n The stacktrace is:\r\n{e.StackTrace}";
                }
                else
                {
                    output += $"Some unexpected exception occured.";
                }
            }
            return Ok(output);
        }

        [HttpGet]
        [Route("echoJson")]
        public async Task<IActionResult> EchoJson(string input)
        {
            var wcfClient = new SampleWcfClient();
            if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
            {
                input = "nothing set";
            }

            var result = new Result();
            var output = "An error has occured \r\n";

            try
            {
                output = await wcfClient.EchoJsonAsync(input);
            }
            catch (CommunicationException commsException)
            {
                if (Environment.IsDevelopment())
                {
                    output += $"The service is unreachable. The error from the exception is: {commsException.Message}";
                }
                else
                {
                    output += $"The service is unreachable.";
                }
            }
            catch (Exception e)
            {
                if (Environment.IsDevelopment())
                {
                    output += $"Some unexpected exception occured. The error message is: {e.Message}\r\n\r\n The stacktrace is:\r\n{e.StackTrace}";
                }
                else
                {
                    output += $"Some unexpected exception occured.";
                }
            }
            finally
            {
                await wcfClient.CloseAsync();
            }

            result.Value = output;
            return Ok(result);
        }

        public class Result
        {
            public string Value { get; set; }
        }
    }
}
