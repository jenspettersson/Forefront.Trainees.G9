using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace FFCG.G9.TemperatureAnalyzer
{
    class FileSourceTemperatureReadingsProvider : ITemperatureReadingsProvider
    {
        public async Task<IEnumerable<TemperatureReading>> GetReadings()
        {
            var baseDirectory = AppDomain.CurrentDomain.BaseDirectory;

            var lines = await File.ReadAllLinesAsync(Path.Combine(baseDirectory, "temperatures.csv"));
            var readings = new List<TemperatureReading>();
            
            foreach (var line in lines)
            {
                var values = line.Split(";");

                readings.Add(new TemperatureReading(DateTime.Parse(values[2]), decimal.Parse(values[1], CultureInfo.InvariantCulture)));
            }

            return readings;
        }
    }
    
    class SmhiTemperatureReadingsProvider : ITemperatureReadingsProvider
    {
        private readonly string _station;

        public SmhiTemperatureReadingsProvider(string station)
        {
            _station = station;
        }
        
        public async Task<IEnumerable<TemperatureReading>> GetReadings()
        {
            string url = $"https://opendata-download-metobs.smhi.se/api/version/1.0/parameter/1/station/{_station}/period/latest-months/data.json";
            var httpClient = new HttpClient();

            var rootResponse = await httpClient.GetFromJsonAsync<RootResponse>(url);

            var readings = new List<TemperatureReading>();
            foreach (var value in rootResponse.value)
            {
                var dateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(long.Parse(value.date.ToString()));
                readings.Add(
                    new TemperatureReading(dateTimeOffset.DateTime, decimal.Parse(value.value, CultureInfo.InvariantCulture))
                );
            }

            return readings;
        }

        private class Value
        {
            public long date { get; set; }
            public string value { get; set; }
        }
        
        private class RootResponse
        {
            public List<Value> value { get; set; }
        }
    }
    
    
}