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
                City = response.CityName,
                Clouds = response.Clouds.Cloudiness,
                Date = DateTime.FromFileTimeUtc(response.DateUtc),
                Humidity = response.Main.Humidity,
                Pressure = response.Main.AtmosphericPressure,
                TemperatureC = (int)response.Main.Temperature - 273,
                WindSpeed = (int)response.Wind.Speed
            };
        }
    }
}
