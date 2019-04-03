using System;
using System.Configuration;
using System.ServiceModel;


namespace ForecastDataServer
{
    sealed class Server
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";

            var host = GetHost();
            host.Open();

            Console.ReadKey();

            host.Close();
        }
        
        private static ServiceHost GetHost()
        {
            var adress = new Uri(string.Format("{0}/IForecastTransfer", ConfigurationManager.AppSettings["Url"]));
            var bindings = new BasicHttpBinding();
            var contract = typeof(IForecastTransfer);

            var host = new ServiceHost(typeof(ForecastTransferService));
            host.AddServiceEndpoint(contract, bindings, adress);

            return host;
        }
    }
}
