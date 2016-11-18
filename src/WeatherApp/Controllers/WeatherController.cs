using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Interfaces;
using WeatherApp.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherApp.Controllers
{
    [Route("api/[controller]")]
    public class WeatherController : Controller
    {
        private IWeatherService _service;

        //GET: api/weather
        [HttpGet]
        public IEnumerable<Weather> Get()
        {
            return _service.GetAllWeather();
        }

        //GET api/weather/:id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.GetWeatherById(id));
        }

        //POST api/weather
        [HttpPost]
        //public IActionResult Post([FromBody]Weather weather)
        //{
        //    _service.SaveWeather(weather);
        //    return Ok(weather);
        //}
        public async Task<IActionResult> Post([FromBody]Weather weather)
        {
            if (ModelState.IsValid)
            {
                await _service.SaveWeather(this.User, weather);
                return Ok(weather);
            }
            else
            {
                return BadRequest();
            }
        }


        //Delete api/weather/:id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.DeleteWeather(id);
            return Ok();
        }

        public WeatherController(IWeatherService service)
        {
            this._service = service;
        }
    }
    
}
