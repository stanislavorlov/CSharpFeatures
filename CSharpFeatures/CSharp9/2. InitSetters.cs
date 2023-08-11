using System;

namespace CSharp9Demo
{
    internal sealed class InitSetters
    {
        public struct Weather
        {
            public DateTime RecordedAt { get; init; }
            public decimal Temperature { get; init; }
            public decimal Pressure { get; init; }

            public override string ToString() =>
                $"At {RecordedAt:h:mm tt} on {RecordedAt:M/d/yyyy}: " +
                $"Temp = {Temperature}, with {Pressure} pressure";
        }

        public static void Run()
        {
            var weather = new Weather
            {
                RecordedAt = DateTime.UtcNow,
                Pressure = 998.0m,
                Temperature = 22.3m
            };

            //Illegal statement, cannot change after initialization
            //weather.Temperature = 40m;

            var weather2 = new Weather();
            //Illegal statement, cannot change after initialization
            //weather2.Pressure = 748;
        }
    }
}
