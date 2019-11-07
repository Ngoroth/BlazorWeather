using BlazorWeather.Domain.Interfaces;
using BlazorWeather.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var forecasts = new List<WeatherForecast>();

            foreach (var city in this.myFavoriteCities)
            {
                forecasts.Add(await this.weatherForecastRepository.GetWeatherForecastByCityNameAsync(city));
            }

            return forecasts.ToArray();
        }
    }
}
