using BlazorWeather.Data.DataSources.OpenWeatherMapApi;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;

namespace BlazorWeather.Data.Tests
{
    [TestClass]
    public class OpenWeatherMapApiDataSourceTests
    {
        [TestMethod]
        public async Task GetWeatherForecastByCityNameAsyncShouldGetMoscowWeather()
        {
            var dataSource = new ApiDataSource("e9a5eecb42d607c03d1c84867c26d193", "http://api.openweathermap.org/");

            var response = await dataSource.GetWeatherForecastByCityNameAsync("Moscow");

            Assert.IsTrue(response.CityName == "Moscow");
        }
    }
}
