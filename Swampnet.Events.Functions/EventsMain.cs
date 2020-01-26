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
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();

            log.LogInformation(requestBody);

            var e = JsonConvert.DeserializeObject<Event>(requestBody);

            return new OkResult();
        }


        [FunctionName("search")]
        public static async Task<IActionResult> Search(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
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
