using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

using BlazorWeather.Domain.OpenWeatherMapApi;

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
    }
}
