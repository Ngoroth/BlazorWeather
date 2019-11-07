using System;

namespace BlazorWeather.Domain.Models
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public string City { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(this.TemperatureC / 0.5556);

        public string Summary { get; set; }

        public int Clouds { get; set; }

        public int Humidity { get; set; }

        public int WindSpeed { get; set; }

        public int Pressure { get; set; }
    }
}
