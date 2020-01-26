using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Swampnet.Events.Functions
{
    public static class EventsMain
    {
        [FunctionName("post-event")]
        public static async Task<IActionResult> PostEvent(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            log.LogInformation(requestBody);

            var e = JsonConvert.DeserializeObject<Event>(requestBody);

            return new OkResult();
            //return e != null
            //    ? (ActionResult)new OkObjectResult($"Hello, {e.Summary}")
            //    : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }


        [FunctionName("search")]
        public static async Task<IActionResult> Search(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            await Task.CompletedTask;

            return (ActionResult)new OkObjectResult(new[] {
                new Event(),
                new Event(),
                new Event()
            });
        }
    }
}
