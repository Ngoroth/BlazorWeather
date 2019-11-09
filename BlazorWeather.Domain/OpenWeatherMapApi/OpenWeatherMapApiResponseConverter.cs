using BlazorWeather.Data.DataSources.OpenWeatherMapApi.Models.Responses;
using BlazorWeather.Domain.Models;
using System;

namespace BlazorWeather.Domain.OpenWeatherMapApi
{
    public class OpenWeatherMapApiResponseConverter
    {
        public WeatherForecast ConvertToWeatherForecast(CurrentForecastResponse response)
        {
            return new WeatherForecast
            {
                City = $"{response.CityName}, {response.System.Country}",
                Clouds = response.Clouds?.Cloudiness ?? 0,
                Date = DateTime.FromFileTimeUtc(response?.DateUtc ?? DateTime.Now.ToFileTimeUtc()),
                Humidity = response.Main?.Humidity ?? 0,
                Pressure = response.Main?.AtmosphericPressure ?? 0,
                TemperatureC = (int)(response.Main?.Temperature ?? 0) - 273,
                WindSpeed = (int)(response.Wind?.Speed ?? 0)
            };
        }
    }
}
