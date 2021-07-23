using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<string> Get(string cityName)
        {
            var URL = $"http://api.weatherapi.com/v1/current.json?key=e86611a19aca4cc5bf121507212307&q={cityName}&aqi=no";
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(URL);
            return await response.Content.ReadAsStringAsync();

        }
    }
}
