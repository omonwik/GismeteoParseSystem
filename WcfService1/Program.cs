using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;


namespace TestApp
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Server";

            var adress = new Uri("http://127.0.0.1:4040/IContract");
            var bindings = new BasicHttpBinding();
            var contract = typeof(IContract);

            var host = new ServiceHost(typeof(Service));
            host.AddServiceEndpoint(contract, bindings, adress);
            host.Open();
        }
    }
}
