using Newtonsoft.Json;

namespace BlazorWeather.Data.DataSources.OpenWeatherMapApi.Models.Responses
{
    [JsonObject]
    public class Wind
    {
        [JsonProperty("speed")]
        public int Speed { get; set; }

        [JsonProperty("deg")]
        public int Direction { get; set; }
    }
}
