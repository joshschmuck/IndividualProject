using System.Collections.Generic;
using System.Security.Principal;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Interfaces
{ 
    public interface IWeatherService
    {
        void DeleteWeather(int it);
        IList<Weather> GetAllWeather();
        Weather GetWeatherById(int id);
        Task SaveWeather(IPrincipal user, Weather weather);
        IList<Weather> SearchByLocation(string searchTerm);
    }
}