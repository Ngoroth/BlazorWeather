using BlazorWeather.Data.DataSources.OpenWeatherMapApi;
using BlazorWeather.Domain.OpenWeatherMapApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BlazorWeather.IntegrationTests
{
    [TestClass]
    public class OpenWeatherMapApiServiceTests
    {
        [TestMethod]
        public async Task GetWeatherForecasts()
        {
            var dataSource = new ApiDataSource("e9a5eecb42d607c03d1c84867c26d193", "http://api.openweathermap.org/");
            var service = new OpenWeatherMapApiService(dataSource);

            var weatherForecasts = await service.GetForecastsAsync();

            Assert.IsTrue(weatherForecasts.Length > 0);
        }
    }
}
