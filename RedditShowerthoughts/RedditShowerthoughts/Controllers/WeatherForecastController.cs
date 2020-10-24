using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace RedditShowerthoughts.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class WeatherForecastController : ControllerBase
  {
    private readonly IHttpClientFactory _clientFactory;
    private static readonly string[] Summaries = new[]
    {
      "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, IHttpClientFactory clientFactory)
    {
      _clientFactory = clientFactory;
      _logger = logger;
    }

    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
      var client = _clientFactory.CreateClient();
      var data = await client.GetAsync("http://www.reddit.com/r/showerthoughts/random.json");
      Console.WriteLine(data);

    }
  }
}
