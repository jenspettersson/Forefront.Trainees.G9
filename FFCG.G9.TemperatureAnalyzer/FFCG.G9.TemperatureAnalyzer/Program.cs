using System;
using System.Linq;
using System.Threading.Tasks;

namespace FFCG.G9.TemperatureAnalyzer
{
    class Program
    {
        static async Task Main(string[] args)
        {
            //var provider = new FileSourceTemperatureReadingsProvider();

            var provider = new SmhiTemperatureReadingsProvider("53430");
            
            var analyzer = new Analyzer(provider);

            var result = await analyzer.Analyze();
            
            Console.WriteLine($"# Readings: {result.NumberOfReadings}");
            Console.WriteLine();
            Console.WriteLine($"^ Highest temp: {result.Highest}");
            Console.WriteLine($"v Lowest temp: {result.Lowest}");
            Console.WriteLine();
            Console.WriteLine($"~ Average: {Math.Round(result.Average, 2)}");
            if (result.NightAverage.HasValue)
            {
                Console.WriteLine($"~ Night Average: {Math.Round(result.NightAverage.Value, 2)}");    
            }

            if (result.DayAverage.HasValue)
            {
                Console.WriteLine($"~ Day Average: {Math.Round(result.DayAverage.Value, 2)}");    
            }
            
            
        }
    }
}