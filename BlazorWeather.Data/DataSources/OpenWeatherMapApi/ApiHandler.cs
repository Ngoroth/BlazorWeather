using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using BlazorWeather.Data.DataSources.OpenWeatherMapApi.Models.Responses;
using BlazorWeather.Domain.Interfaces;
using BlazorWeather.Domain.Models;

namespace BlazorWeather.Data.DataSources.OpenWeatherMapApi
{
    public class ApiHandler : IWeatherForecastRepository
    {
        private readonly string appId;
        private readonly HttpClient weatherApiClient;
        private ResponseConverter responseConverter;

        public ApiHandler(string appId, string baseApiUrl = "http://api.openweathermap.org/")
        {
            this.appId = appId;

            this.weatherApiClient = new HttpClient
            {
                BaseAddress = new Uri(baseApiUrl)
            };

            this.responseConverter = new ResponseConverter();
        }

        public async Task<WeatherForecast> GetWeatherForecastByCityNameAsync(string cityName)
        {
            var responseMessage = await this.weatherApiClient.GetAsync(this.createQueryString(cityName));
            //todo add status code validation
            var responseContentString = await responseMessage.Content.ReadAsStringAsync();

            var currentForecast = JsonConvert.DeserializeObject<CurrentForecastResponse>(responseContentString);

            return this.responseConverter.ConvertToWeatherForecast(currentForecast);
        }

        private string createQueryString(string cityName)
        {
            return $"data/2.5/weather?q={cityName}&appid={this.appId}";
        }
    }
}
