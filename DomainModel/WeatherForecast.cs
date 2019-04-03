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
        [Required]
        public string ParseDate { get; set; }
    }
}
