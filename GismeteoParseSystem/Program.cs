using System;
using System.Configuration;
using System.Threading;

namespace GismeteoParseSystem
{
    sealed class Program
    {
        private const int millisInMinute = 60000;

        static void Main(string[] args)
        {
            var gismeteoService = new GismeteoService();
            var updateIntervalConfig = ConfigurationManager.AppSettings["updateMinuteInterval"];
            var updateInterval = int.Parse(updateIntervalConfig);

            while (true)
            {
                var logDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
                Console.WriteLine($"{logDate}: ���������� ������ � ������");
                gismeteoService.UpdateWeatherForecast();
                Console.WriteLine("������ � ������ ���������");
                Thread.Sleep(updateInterval * millisInMinute);
            }
        }
    }
}
