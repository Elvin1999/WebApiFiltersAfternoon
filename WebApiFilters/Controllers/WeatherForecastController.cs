using Microsoft.AspNetCore.Mvc;
using WebApiFilters.Filters;

namespace WebApiFilters.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        //[ServiceFilter(typeof(CustomActionFilter))]
        [ServiceFilter(typeof(CustomResultFilter))]
        [HttpGet]
        public ActionResult TestFilter(string? name, string? surname)
        {

            return Ok(new { Name = name, Surname = surname });
        }
    }
}
