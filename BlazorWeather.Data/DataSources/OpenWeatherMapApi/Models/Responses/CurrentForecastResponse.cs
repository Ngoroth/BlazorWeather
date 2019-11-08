using Newtonsoft.Json;
using System;

namespace BlazorWeather.Data.DataSources.OpenWeatherMapApi.Models.Responses
{
    [JsonObject]
    public class CurrentForecastResponse
    {
        [JsonProperty("main")]
        public MainWeatherData Main { get; set; }

        [JsonProperty("wind")]
        public Wind Wind { get; set; }

        [JsonProperty("clouds")]
        public Clouds Clouds { get; set; }

        [JsonProperty("id")]
        public int CityId { get; set; }

        [JsonProperty("name")]
        public string CityName { get; set; }

        [JsonProperty("dt")]
        public long DateUtc { get; set; }
    }
}
