using Newtonsoft.Json;

namespace BlazorWeather.Data.DataSources.OpenWeatherMapApi
{
    [JsonObject]
    public class CurrentForecastResponse
    {
        [JsonProperty("main")]
        public MainWeatherData main { get; set; }

        [JsonProperty("wind")]
        public Wind wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds clouds { get; set; }

        [JsonProperty("id")]
        public int CityId { get; set; }

        [JsonProperty("name")]
        public string CityName { get; set; }
    }
}
