using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

using BlazorWeather.Domain.Interfaces;
using BlazorWeather.Domain.Models;

namespace BlazorWeather.Domain
{
    public class OpenWeatherMapForecastService : IWeatherForecastService
    {
        private readonly HttpClient weatherApiClient;

        private string[] myFavoriteCities;

        public OpenWeatherMapForecastService()
        {
            this.weatherApiClient = new HttpClient()
            {
                BaseAddress = new Uri("http://api.openweathermap.org/")
            };

            this.myFavoriteCities = new[] { "Moscow", "Nizhniy Tagil", "Prague", "Venice", "Kyoto" };
        }
        public async Task<WeatherForecast[]> GetForecastsAsync()
        {
            var responseMessage = await this.weatherApiClient.GetAsync("data/2.5/weather?q=Moscow&appid=e9a5eecb42d607c03d1c84867c26d193");

            var responseStr = await responseMessage.Content.ReadAsStringAsync();

            dynamic responseObj = JsonConvert.DeserializeObject(responseStr);

            return new WeatherForecast[] { };


        }
    }
}
