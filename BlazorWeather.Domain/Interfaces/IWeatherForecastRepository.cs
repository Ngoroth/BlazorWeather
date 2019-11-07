using System.Threading.Tasks;

using BlazorWeather.Domain.Models;

namespace BlazorWeather.Domain.Interfaces
{
    public interface IWeatherForecastRepository
    {
        Task<WeatherForecast> GetWeatherForecastByCityNameAsync(string cityName);
    }
}
