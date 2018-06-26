
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Linq;
using System;
using OpenWeather.Server.Response;

namespace OpenWeather.Server
{
    public static class Webhook
    {
        [FunctionName("Function1")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequest req, TraceWriter log)
        {
            return new JsonResult(new Response.DialogflowResponse
            {
                Payload = new Response.Payload
                {
                    Google = new Response.Google
                    {
                        ExpectUserResponse = true,
                        RichResponse = new Response.RichResponse
                        {
                            Items = new[]
                            {
                                new Response.Item
                                {
                                    SimpleResponse = new Response.SimpleResponse
                                    {
                                        TextToSpeech = "ÇøÇÂÇ‹Ç«ÇæÇÊÅI"
                                    }
                                }
                            }
                        },
                        UserStorage = "{\"data\":{}}"
                    },
                },
                OutputContexts = Array.Empty<OutputContext>(),
            });
        }
    }
}
