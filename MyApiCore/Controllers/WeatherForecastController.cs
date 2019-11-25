using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace MyApiCore.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<WeatherForecast>> Get()
        {
            var rng = new Random();

            //Teste
           // if (1 != 1) return BadRequest();

            return Ok(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var rng = new Random();

            //Teste
            //if (1 != 1) return BadRequest();

            return Ok(Enumerable.Range(1, 5)
                      .Select(index => new WeatherForecast
                      {
                          Date = DateTime.Now.AddDays(index),
                          TemperatureC = rng.Next(-20, 55),
                          Summary = Summaries[rng.Next(Summaries.Length)]
                      }).ToArray());
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetResult()
        {
            var rng = new Random();

            //Teste 
           // if (1 != 1) return null;

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray();
        }

        [HttpPost] 
        [ProducesResponseType(typeof(Product), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post(Product product)
        {
            if (product.Id == 0) return BadRequest();

            //return Ok(product);//Retorna 200
            //return CreatedAtAction("Post", product);retorna 201
            return CreatedAtAction(nameof(Post), product);//retorna 201
        }
    }

    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
