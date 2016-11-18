using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Data;
using WeatherApp.Interfaces;
using WeatherApp.Models;

namespace WeatherApp.Repository
{
    public class EFRepository : IDisposable, IRepository
    {
        private ApplicationDbContext _db;

        public EFRepository(ApplicationDbContext db)
        {
            this._db = db;
        }

        public IList<Weather> ListWeather()
        {
            return _db.Weather.ToList();
        }

        public Weather FindWeather(int id)
        {
            return _db.Weather.FirstOrDefault(w => w.Id == id);
        }

        public void CreateWeather(Weather weatherToCreate)
        {
            _db.Weather.Add(weatherToCreate);
            _db.SaveChanges();
        }

        public void UpdateWeather(Weather weatherToUpdate)
        {
            var originalWeather = this.FindWeather(weatherToUpdate.Id);
            originalWeather.UserName = weatherToUpdate.UserName;
            originalWeather.Location = weatherToUpdate.Location;
            originalWeather.Description = weatherToUpdate.Description;
            originalWeather.Item = weatherToUpdate.Item;
            _db.SaveChanges();
        }

        public void DeleteWeather(int id)
        {
            var originalWeather = this.FindWeather(id);
            _db.Weather.Remove(originalWeather);
            _db.SaveChanges();
        }

        public void Dispose()
        {
            _db.Dispose();
        }
    }

}
