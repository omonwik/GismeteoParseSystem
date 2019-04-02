using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WCFLayer
{
    public sealed class Server
    {
        static void Main()
        {
            Console.Title = "Server";

            var adress = new Uri("http://localhost:65383/IContract");
            var bindings = new BasicHttpBinding();
            var contract = typeof(IContract);

            var host = new ServiceHost(typeof(Service));
            host.AddServiceEndpoint(contract, bindings, adress);
            host.Open();
        }
    }
}