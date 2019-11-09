using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

using BlazorWeather.Domain.OpenWeatherMapApi;
using System.Linq;

namespace BlazorWeather.IntegrationTests
{
    [TestClass]
    public class OpenWeatherMapApiServiceTests
    {
        [TestMethod]
        public async Task GetWeatherForecasts()
        {
            var service = new OpenWeatherMapApiService();
            var myFavoriteCities = new[] { "Moscow", "Nizhniy Tagil", "Prague", "Venice", "Kyoto"};

            var weatherForecasts = await service.GetForecastsAsync(myFavoriteCities);

            Assert.IsTrue(weatherForecasts.Length > 0);
        }

        [TestMethod]
        public async Task GetWeatherForecastWithByWrongCityName()
        {
            var service = new OpenWeatherMapApiService();

            var weatherForecast = (await service.GetForecastsAsync("test18")).First();

            Assert.IsTrue(weatherForecast.City == "City not found, Nowhere");
        }
    }
}
