using DomainModel;
using System.Linq;

namespace ForecastDataServer
{
    public sealed class ForecastTransferService : IForecastTransfer
    {
        private readonly ForecastContext _context;

        public ForecastTransferService()
        {
            _context = new ForecastContext();
        }

        public WeatherForecast GetData()
        {
            return _context.WeatherForecasts.OrderByDescending(forecast => forecast.Id).FirstOrDefault();
        }
    }
}
