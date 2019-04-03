using DomainModel;
using HtmlAgilityPack;
using System;
using System.Net;
using System.Text;

namespace GismeteoParseSystem
{
    sealed class GismeteoParseManager
    {
        private readonly ForecastContext _context;
        private readonly GismeteoParser _parser;

        public GismeteoParseManager()
        {
            _context = new ForecastContext();
            _parser = new GismeteoParser();
        }

        public void ParseWeather()
        {
            var document = GetGismeteoMainPageHtmlDocument();
            var forecast = _parser.Parse(document);

            _context.WeatherForecasts.Add(forecast);
            _context.SaveChanges();
            Console.WriteLine("Данные о погоде обновлены");
        }

        private HtmlDocument GetGismeteoMainPageHtmlDocument()
        {
            string html = null;
            var document = new HtmlDocument();

            using (var client = new WebClient())
            {
                client.Encoding = Encoding.UTF8;
                html = client.DownloadString("https://www.gismeteo.by/");
            }

            document.LoadHtml(html);
            return document;
        }


        private sealed class GismeteoParser
        {
            public WeatherForecast Parse(HtmlDocument document)
            {
                var forecast = new WeatherForecast();

                if (document == null) return forecast;

                ParseCity(document, forecast);
                ParseFilling(document, forecast);
                ParseGeomagneticField(document, forecast);
                ParseHumidity(document, forecast);
                ParsePressure(document, forecast);
                ParseTemperature(document, forecast);
                ParseWhaterTemperature(document, forecast);
                ParseWind(document, forecast);

                forecast.ParseDate = DateTime.Now.ToString("hh:mm dd/MM/yyyy");
                return forecast;
            }

            private void ParseCity(HtmlDocument document, WeatherForecast forecast)
            {
                if (document == null) return;

                var city = document.DocumentNode.SelectSingleNode("//div[@class='weather_frame_title clearfix']//a[@class='link blue weather_current_link no_border']");
                if (city != null)
                {
                    forecast.City = city.InnerText.Trim();
                }
            }

            private void ParseTemperature(HtmlDocument document, WeatherForecast forecast)
            {
                if (document == null) return;

                var temperature = document.DocumentNode.SelectSingleNode("//div[@class='js_meas_container temperature']/span[@class='value unit unit_temperature_c']");
                if (temperature != null)
                {
                    forecast.Temperature = temperature.InnerText.Trim();
                }
            }

            private void ParseFilling(HtmlDocument document, WeatherForecast forecast)
            {
                if (document == null) return;

                var feeling = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'info_item clearfix') and contains(.//div, 'ощущению')]/div[@class='ii info_value']/span[@class='value unit unit_temperature_c']");
                if (feeling != null)
                {
                    forecast.Feeling = feeling.InnerText.Replace("&minus;", "-").Trim();
                }
            }

            private void ParseWind(HtmlDocument document, WeatherForecast forecast)
            {
                if (document == null) return;

                var wind = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'info_item clearfix') and contains(.//div, 'Ветер')]/div[@class='ii info_value']/span[@class='unit unit_wind_m_s']");
                if (wind != null)
                {
                    forecast.Wind = wind.InnerText.Trim();
                }
            }

            private void ParsePressure(HtmlDocument document, WeatherForecast forecast)
            {
                if (document == null) return;

                var pressure = document.DocumentNode.SelectSingleNode("//span[@class='unit unit_pressure_mm_hg_atm']");
                if (pressure != null)
                {
                    forecast.Pressure = pressure.InnerText.Trim();
                }
            }

            private void ParseHumidity(HtmlDocument document, WeatherForecast forecast)
            {
                if (document == null) return;

                var humidity = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'info_item clearfix') and contains(.//div, 'Влажность')]/div[@class='ii info_value']");
                if (humidity != null)
                {
                    forecast.Humidity = humidity.InnerText.Replace("&nbsp;", " ").Trim();
                }
            }

            private void ParseGeomagneticField(HtmlDocument document, WeatherForecast forecast)
            {
                if (document == null) return;

                var geomagneticField = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'info_item clearfix') and contains(.//div, 'Геомагнитное')]/div[@class='ii info_value']");
                if (geomagneticField != null)
                {
                    forecast.GeomagneticField = geomagneticField.InnerText.Trim();
                }
            }

            private void ParseWhaterTemperature(HtmlDocument document, WeatherForecast forecast)
            {
                if (document == null) return;

                var waterTemperature = document.DocumentNode.SelectSingleNode("//div[contains(@class, 'info_item clearfix') and contains(.//div, 'воды')]/div[@class='ii info_value']/span[@class='value unit unit_temperature_c']");
                if (waterTemperature != null)
                {
                    forecast.WaterTemperature = waterTemperature.InnerText.Trim();
                }
            }
        }
    }
}
