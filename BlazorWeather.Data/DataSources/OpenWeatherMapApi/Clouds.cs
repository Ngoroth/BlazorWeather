using Newtonsoft.Json;

namespace BlazorWeather.Data.DataSources.OpenWeatherMapApi
{
    [JsonObject]
    public class Clouds
    {
        [JsonProperty("all")]
        public int Cloudiness { get; set; }
    }
}
