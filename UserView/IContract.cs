using DomainModel;
using System.ServiceModel;

namespace UserView
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        WeatherForecast GetData();
    }
}
