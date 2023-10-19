using Microsoft.AspNetCore.Mvc;
using student.application.IService;
using student.domain.Entity;

namespace student.api.Controllers
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
        private readonly IStudentService _studentService;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        [HttpPost("AddData")]
        public async Task<IActionResult> AddData(Student student)
        {
            await _studentService.Add(student);
            return Ok();
        }

        [HttpGet("data")]
        public async Task<IActionResult> GetData()
        {
            var data = await _studentService.Get();
            return Ok(data);
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
    }
}