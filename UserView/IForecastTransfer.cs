using DomainModel;
using System.ServiceModel;

namespace UserView
{
    [ServiceContract]
    public interface IForecastTransfer
    {
        [OperationContract]
        WeatherForecast GetData();
    }
}
