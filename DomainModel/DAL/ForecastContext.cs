using System.Configuration;
using System.Data.Entity;
using MySql.Data.Entity;

namespace DomainModel
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public sealed class ForecastContext : DbContext
    {
        public DbSet<WeatherForecast> WeatherForecasts { get; set; }

        private static readonly string connectionString;

        static ForecastContext()
        {
            connectionString = "server=localhost;port=7777;database=Forecast;uid=root;password=avg291971";
        }

        public ForecastContext() : base(connectionString)
        {

        }
    }
}
