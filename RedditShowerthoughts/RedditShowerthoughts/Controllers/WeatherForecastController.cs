using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
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
    public async Task<IActionResult> Get()
    {
      var client = _clientFactory.CreateClient();
      var response = await client.GetAsync("http://www.reddit.com/r/showerthoughts/random.json");

      if (response.IsSuccessStatusCode)
      {
        var responseString = await response.Content.ReadAsStringAsync();
        var post = JsonSerializer.Deserialize<IEnumerable<RedditPostResponse>>(responseString).ToList();

        return Ok(post[0].Data.Children.ToList()[0].Data.Title);
      }
      else
      {
        return StatusCode(500);
      }
    }
  }
}
