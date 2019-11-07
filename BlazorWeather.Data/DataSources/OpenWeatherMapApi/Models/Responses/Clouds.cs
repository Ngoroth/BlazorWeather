using Newtonsoft.Json;

namespace BlazorWeather.Data.DataSources.OpenWeatherMapApi.Models.Responses
{
    [JsonObject]
    public class Clouds
    {
        [JsonProperty("all")]
        public int Cloudiness { get; set; }
    }
}
