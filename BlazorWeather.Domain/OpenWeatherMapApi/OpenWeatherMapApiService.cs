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
        private readonly string[] myFavoriteCities;
        private readonly OpenWeatherMapApiResponseConverter apiResponseConverter;

        public OpenWeatherMapApiService(ApiDataSource dataSource)
        {
            this.dataSource = dataSource;
            this.myFavoriteCities = new[] { "Moscow", "Prague", "Venice", "Kyoto"};
            this.apiResponseConverter = new OpenWeatherMapApiResponseConverter();
        }

        public Task<WeatherForecast[]> GetForecastsAsync()
        {
            var forecastTasks = new List<Task<WeatherForecast>>();

            foreach (var city in this.myFavoriteCities.AsEnumerable())
            {
                forecastTasks.Add(this.dataSource.GetWeatherForecastByCityNameAsync(city)
                    .ContinueWith(resp => this.apiResponseConverter.ConvertToWeatherForecast(resp.Result)));
            }

            return Task.WhenAll(forecastTasks);
        }
    }
}
