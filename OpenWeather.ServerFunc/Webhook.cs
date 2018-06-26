using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Host;
using OpenWeather.ServerFunc.Response;

namespace OpenWeather.ServerFunc
{
    public static class Webhook
    {
        [FunctionName("Webhook")]
        public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
        {
            var json = await req.Content.ReadAsStringAsync();
            log.Info(json);
            var request = OpenWeather.ServerFunc.Request.DialogflowRequest.FromJson(json);
            var city = request.QueryResult.Parameters.Value<string>("City");

            return req.CreateResponse(new Response.DialogflowResponse
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
                                        TextToSpeech = $"ちょまどだよ！ {city}"
                                    }
                                }
                            }
                        },
                    },
                },
                OutputContexts = Array.Empty<OutputContext>(),
            });
        }
    }
}
