using System;
using System.Collections.Generic;

namespace TestApp
{
    public sealed class Service : IContract
    {
        private readonly string[] randomStrings = new string[]
        {
            "Test1",
            "Test2",
            "Test4",
            "Test5",
            "Test6",
            "Test7",
            "Test8",
            "Test9",
            "Test10",
        };

        public string GetData()
        {
            var random = new Random();
            var number = random.Next(0, 9);
            return randomStrings[number];
        }
    }
}
