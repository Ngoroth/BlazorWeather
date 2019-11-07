using BlazorWeather.Data.DataSources.OpenWeatherMapApi.Models.Responses;
using BlazorWeather.Domain.Models;

namespace BlazorWeather.Data.DataSources.OpenWeatherMapApi
{
    public class ResponseConverter
    {
        public WeatherForecast ConvertToWeatherForecast(CurrentForecastResponse response)
        {
            return new WeatherForecast
            {
                City = response.CityName,
                Clouds = response.Clouds.Cloudiness,
                Date = response.Date,
                Humidity = response.Main.Humidity,
                Pressure = response.Main.AtmosphericPressure,
                TemperatureC = (int)response.Main.Temperature - 273,
                WindSpeed = response.Wind.Speed
            };
        }
    }
}
