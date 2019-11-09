using System.ComponentModel.DataAnnotations;

namespace BlazorWeather.Models
{
    public class SearchWeatherForecastModel
    {
        [Required]
        [RegularExpression("^[a-zA-Z ]+$", ErrorMessage = "Only latin letters and whitespace allowed!")]
        public string CityName { get; set; }
    }
}
