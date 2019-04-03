using DomainModel;
using System.Linq;

namespace TestApp
{
    public sealed class Service : IContract
    {
        private readonly ForecastContext _context;

        public Service()
        {
            _context = new ForecastContext();
        }

        public WeatherForecast GetData()
        {
            return _context.WeatherForecasts.OrderByDescending(forecast => forecast.Id).FirstOrDefault();
        }
    }
}
