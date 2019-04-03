using System.ComponentModel.DataAnnotations;

namespace DomainModel
{
    public sealed class WeatherForecast
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Temperature { get; set; }
        [Required]
        public string Feeling { get; set; }
        [Required]
        public string Wind { get; set; }
        [Required]
        public string Pressure { get; set; }
        [Required]
        public string Humidity { get; set; }
        [Required]
        public string GeomagneticField { get; set; }
        [Required]
        public string WaterTemperature { get; set; }

        public WeatherForecast(string city, string temperature, string feeling, string wind,
                               string pressure, string humidity, string geomagneticField,
                               string waterTemperature)
        {
            City = city;
            Temperature = temperature;
            Feeling = feeling;
            Wind = wind;
            Pressure = pressure;
            Humidity = humidity;
            GeomagneticField = geomagneticField;
            WaterTemperature = waterTemperature;
        }
    }
}
