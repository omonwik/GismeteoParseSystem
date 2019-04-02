using System.ServiceModel;

namespace TestApp
{
    [ServiceContract]
    public interface IContract
    {
        [OperationContract]
        string GetData();
    }
}
