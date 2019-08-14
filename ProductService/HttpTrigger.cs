using System.Net.Http;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;


namespace ProductService
{
    public class HttpTrigger
    {
        private readonly HttpClient _client;
        private readonly IMediator _mediator;

        public HttpTrigger(IMediator mediator,IHttpClientFactory httpClientFactory)
        {
            _mediator = mediator;
            _client = httpClientFactory.CreateClient();
        }

        [FunctionName("GetPosts")]
        public async Task<IActionResult> Get([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "posts")]
            HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            var res = await _client.GetAsync("https://microsoft.com");
            log.LogInformation(await res.Content.ReadAsStringAsync());
            return new OkResult();
        }
    }
}