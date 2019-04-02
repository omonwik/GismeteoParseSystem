using HtmlAgilityPack;
using System;
using System.Net;
using System.Text;

namespace GismeteoParseSystem
{
    sealed class Program
    {
        static void Main(string[] args)
        {
            string html = null;
            var document = new HtmlDocument();

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
