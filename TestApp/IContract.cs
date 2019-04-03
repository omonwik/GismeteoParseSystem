using DomainModel;
using System.ServiceModel;

namespace TestApp
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        WeatherForecast GetData();
    }
}
