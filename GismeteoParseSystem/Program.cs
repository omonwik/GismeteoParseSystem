using System;
using System.Threading;

namespace GismeteoParseSystem
{
    sealed class Program
    {

        static void Main(string[] args)
        {
            var parseManager = new GismeteoParseManager();
            var count = 1;

            while (true)
            {
                Console.WriteLine($"Обновление данных о погоде №{count}");
                count++;
                parseManager.ParseWeather();
                Thread.Sleep(60000);
            }
        }
    }
}
