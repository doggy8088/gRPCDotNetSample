using gRPCDotNetSample.Service;
using Microsoft.AspNetCore.Mvc;

namespace gRPCDotNetSample.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly Greeter.GreeterClient client;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, Greeter.GreeterClient client)
        {
            _logger = logger;
            this.client = client;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("test")]
        public HelloReply Get1()
        {
            return client.SayHello(new HelloRequest() { Name = "Will" });
        }
    }
}