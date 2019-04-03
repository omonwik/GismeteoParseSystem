using DomainModel;
using HtmlAgilityPack;
using MySql.Data.MySqlClient;
using System;
using System.Net;
using System.ServiceModel;
using System.Text;

namespace GismeteoParseSystem
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            string html = null;
            var document = new HtmlDocument();
            var context = new ForecastContext();

            var forecast = new WeatherForecast("Москва", "+4", "+3", "3", "2.2", "22", "123", "+1");
            context.WeatherForecasts.Add(forecast);
            context.SaveChanges();

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                html = client.DownloadString("https://www.gismeteo.ru/");
            }

            document.LoadHtml(html);
            ParseHtml(document);

            Console.ReadKey();
        }

        private static void ParseHtml(HtmlDocument document)
        {
            if (document == null) return;

            var s = document.DocumentNode.SelectSingleNode("//a[@class='link blue weather_current_link no_border']");
            if (s == null) return;

            Console.WriteLine(s.InnerText);
            Console.ReadKey();
        }
    }
}
