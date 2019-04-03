using DomainModel;
using System;
using System.Configuration;
using System.ServiceModel;

namespace UserView
{
    sealed class GismeteoDataManager
    {
        public static WeatherForecast GetActualForecast()
        {
            var chanel = GetContractChangel();
            var forecast = chanel.GetData();

            return forecast;
        }

        private static IForecastTransfer GetContractChangel()
        {
            var adress = new Uri(ConfigurationManager.AppSettings["Uri"]);
            var bindings = new BasicHttpBinding();
            var endpoint = new EndpointAddress(adress);

            var factory = new ChannelFactory<IForecastTransfer>(bindings, endpoint);

            return factory.CreateChannel();
        }
    }
}
