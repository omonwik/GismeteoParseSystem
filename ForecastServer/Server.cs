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

            Console.WriteLine("Server started successfully");
            Console.ReadKey();

            host.Close();
        }
        
        private static ServiceHost GetHost()
        {
            var address = new Uri(ConfigurationManager.AppSettings["Uri"]);
            var bindings = new BasicHttpBinding();
            var contract = typeof(IForecastTransfer);

            var host = new ServiceHost(typeof(ForecastTransferService));
            host.AddServiceEndpoint(contract, bindings, address);

            return host;
        }
    }
}
