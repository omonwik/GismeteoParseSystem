using DomainModel;
using System.ServiceModel;

namespace ForecastDataServer
{
    [ServiceContract]
    public interface IForecastTransfer
    {
        [OperationContract]
        WeatherForecast GetData();
    }
}
