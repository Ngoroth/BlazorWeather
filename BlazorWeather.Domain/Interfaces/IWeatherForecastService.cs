using System.Threading.Tasks;

using BlazorWeather.Domain.Models;

namespace BlazorWeather.Domain.Interfaces
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastsAsync();
    }
}
