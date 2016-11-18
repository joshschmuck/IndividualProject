using System.Collections.Generic;
using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
    public interface IRepository
    {
        void CreateWeather(Weather weatherToCreate);
        void DeleteWeather(int id);
        void Dispose();
        Weather FindWeather(int id);
        IList<Weather> ListWeather();
        void UpdateWeather(Weather weatherToUpdate);
    }
}