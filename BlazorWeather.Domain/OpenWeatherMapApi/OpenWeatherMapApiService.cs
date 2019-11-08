using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using BlazorWeather.Data.DataSources.OpenWeatherMapApi;
using BlazorWeather.Data.DataSources.OpenWeatherMapApi.Models.Responses;
using BlazorWeather.Domain.Interfaces;
using BlazorWeather.Domain.Models;

namespace BlazorWeather.Domain.OpenWeatherMapApi
{
    public class OpenWeatherMapApiService : IWeatherForecastService
    {
        private readonly ApiDataSource dataSource;
        private readonly OpenWeatherMapApiResponseConverter apiResponseConverter;

        public OpenWeatherMapApiService()
        {
            this.dataSource = new ApiDataSource("e9a5eecb42d607c03d1c84867c26d193", "http://api.openweathermap.org/");
            this.apiResponseConverter = new OpenWeatherMapApiResponseConverter();
        }

        public Task<WeatherForecast[]> GetForecastsAsync(params string[] cities)
        {
            var forecastTasks = new List<Task<WeatherForecast>>();

            foreach (var city in cities.AsEnumerable())
            {
                forecastTasks.Add(this.dataSource.GetWeatherForecastByCityNameAsync(city)
                    .ContinueWith(resp => this.apiResponseConverter.ConvertToWeatherForecast(resp.Result)));
            }

            return Task.WhenAll(forecastTasks);
        }
    }
}
