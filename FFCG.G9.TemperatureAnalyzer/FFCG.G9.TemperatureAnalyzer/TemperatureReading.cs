using System;

namespace FFCG.G9.TemperatureAnalyzer
{
    public record TemperatureReading
    {
        public DateTime Time { get; }
        public decimal Temperature { get; }

        public TemperatureReading(DateTime time, decimal temperature)
        {
            Time = time;
            Temperature = temperature;
        }

        public override string ToString()
        {
            return $"{Temperature} ({Time})";
        }
    }
}