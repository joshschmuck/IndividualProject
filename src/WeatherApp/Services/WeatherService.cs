using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.Repository;

namespace WeatherApp.Interfaces
{
    public class WeatherService : IWeatherService
    {
        private IGenericRepository _repo;
        private UserManager<ApplicationUser> _manager;
        public WeatherService(IGenericRepository repo, UserManager<ApplicationUser> manager)
        {
            _repo = repo;
            _manager = manager;
        }
        
        public IList<Weather> GetAllWeather()
        {
            return _repo.Query<Weather>().ToList();
        }

        public Weather GetWeatherById(int id)
        {
            return _repo.Query<Weather>().Where(w => w.Id == id).FirstOrDefault();
        }

        //public void SaveWeather(Weather weather)
        //{
        //    if(weather.Id == 0)
        //    {
        //        _repo.Add(weather);
        //    }
        //    else
        //    {
        //        _repo.Update(weather);
        //    }
        //}

        public async Task SaveWeather(IPrincipal user, Weather weather)
        {
            var appUser = await _manager.FindByNameAsync(user.Identity.Name);
            weather.UserId = appUser.Id;
            weather.UserName = appUser.UserName;

            if (weather.Id == 0)
            {
                _repo.Add(weather);
            }

            else
            {
                _repo.Update(weather);
            }
        }

        public void DeleteWeather(int id)
        {
            Weather weatherToDelete = _repo.Query<Weather>().Where(w => w.Id == id).FirstOrDefault();
            _repo.Delete(weatherToDelete);
        }

        public IList<Weather> SearchByLocation(string searchTerm)
        {
            var weather = _repo.Query<Weather>();
            return (from w in weather
                    where w.Location == searchTerm
                    select new Weather
                    {
                        UserName = w.UserName,
                        Location = w.Location,
                        Description = w.Description,
                        Item = w.Item
                    }).ToList();
        }

        public WeatherService(IGenericRepository repo)
        {
            this._repo = repo;
        }

        public ApplicationUser GetUserByName(string userName)
        {
            var data = _repo.Query<ApplicationUser>().Where(u => u.UserName == userName).FirstOrDefault();
            return data;
        }
    }
}
