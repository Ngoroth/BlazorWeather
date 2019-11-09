using System;
using System.Net.Http;
using System.Threading.Tasks;

using Newtonsoft.Json;

using BlazorWeather.Data.DataSources.OpenWeatherMapApi.Models.Responses;

namespace BlazorWeather.Data.DataSources.OpenWeatherMapApi
{
    public class ApiDataSource
    {
        private readonly string appId;
        private readonly HttpClient weatherApiClient;

        public ApiDataSource(string appId, string baseApiUrl)
        {
            this.appId = appId;

            this.weatherApiClient = new HttpClient
            {
                BaseAddress = new Uri(baseApiUrl)
            };
        }

        public async Task<CurrentForecastResponse> GetWeatherForecastByCityNameAsync(string cityName)
        {
            var responseMessage = await this.weatherApiClient.GetAsync(this.createQueryString(cityName));
            
            if(!responseMessage.IsSuccessStatusCode)
            {
                return createCityNotFoundResponse();
            }

            var responseContentString = await responseMessage.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CurrentForecastResponse>(responseContentString);
        }

        private static CurrentForecastResponse createCityNotFoundResponse()
        {
            return new CurrentForecastResponse
            {
                CityName = "City not found",
                System = new SystemData
                {
                    Country = "Nowhere"
                }
            };
        }

        private string createQueryString(string cityName)
        {
            return $"data/2.5/weather?q={cityName}&appid={this.appId}";
        }
    }
}
