using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FFCG.G9.TemperatureAnalyzer
{
    public class Analyzer
    {
        private readonly ITemperatureReadingsProvider _readingsProvider;
        private const int NightStart = 0;
        private const int NightEnd = 5;
        
        private const int DayStart = 8;
        private const int DayEnd = 17;

        public Analyzer(ITemperatureReadingsProvider readingsProvider)
        {
            _readingsProvider = readingsProvider;
        }
        
        public async Task<Result> Analyze()
        {
            var readings = (await _readingsProvider.GetReadings()).ToList();
            
            var max = readings.OrderBy(x => x.Time).FirstOrDefault(x => x.Temperature == readings.Max(r => r.Temperature));
            var min = readings.OrderBy(x => x.Time).FirstOrDefault(x => x.Temperature == readings.Min(r => r.Temperature));

            return new()
            {
                Average = GetAverage(readings).GetValueOrDefault(),
                NightAverage = GetAverage(readings, x => x.Time.Hour >= NightStart && x.Time.Hour < NightEnd),
                DayAverage = GetAverage(readings, x => x.Time.Hour >= DayStart && x.Time.Hour < DayEnd),
                Highest = max,
                Lowest = min,
                NumberOfReadings = readings.Count
            };
        }

        private decimal? GetAverage(List<TemperatureReading> readings, Func<TemperatureReading, bool> predicate = null)
        {
            if (predicate == null)
                return readings.Average(x => x.Temperature);
            
            if (readings.Any(predicate))
            {
                return readings.Where(predicate).Average(x => x.Temperature);
            }

            return null;
        }
    }
}