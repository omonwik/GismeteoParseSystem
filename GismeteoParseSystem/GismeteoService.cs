using DomainModel;
using HtmlAgilityPack;
using System.Configuration;
using System.Net;
using System.Text;

namespace GismeteoParseSystem
{
    public sealed class GismeteoService
    {
        private readonly ForecastContext _context;
        private readonly GismeteoParser _gismeteoParser;

        public GismeteoService()
        {
            _context = new ForecastContext();
            _gismeteoParser = new GismeteoParser();
        }

        public void UpdateWeatherForecast()
        {
            var document = GetMainPageHtmlDocument();
            var forecast = _gismeteoParser.Parse(document);

            _context.WeatherForecasts.Add(forecast);
            _context.SaveChanges();
        }

        private HtmlDocument GetMainPageHtmlDocument()
        {
            var document = new HtmlDocument();
            var url = ConfigurationManager.AppSettings["gismeteoUrl"];

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                var html = client.DownloadString(url);
                document.LoadHtml(html);
            }

            return document;
        }
    }
}
