using System.Collections.Generic;
using System.Threading.Tasks;

using BlazorWeather.Domain.Interfaces;
using BlazorWeather.Domain.Models;

namespace BlazorWeather.Domain
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IWeatherForecastRepository weatherForecastRepository;
        private readonly string[] myFavoriteCities;

        public WeatherForecastService(IWeatherForecastRepository weatherForecastRepository)
        {
            this.weatherForecastRepository = weatherForecastRepository;

            this.myFavoriteCities = new[] { "Moscow", "Nizhniy Tagil", "Prague", "Venice", "Kyoto" };
        }

        public async Task<WeatherForecast[]> GetForecastsAsync()
        {
            var forecastTasks = new List<Task<WeatherForecast>>();

            foreach (var city in this.myFavoriteCities)
            {
                forecastTasks.Add(this.weatherForecastRepository.GetWeatherForecastByCityNameAsync(city));
            }

            return await Task.WhenAll<WeatherForecast>();
        }
    }
}
