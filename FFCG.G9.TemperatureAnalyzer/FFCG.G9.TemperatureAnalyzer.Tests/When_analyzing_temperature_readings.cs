using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G9.TemperatureAnalyzer.Tests
{
    public class TestProvider : ITemperatureReadingsProvider
    {
        private readonly IEnumerable<TemperatureReading> _readings;

        public TestProvider(IEnumerable<TemperatureReading> readings)
        {
            _readings = readings;
        }
        
        public Task<IEnumerable<TemperatureReading>> GetReadings()
        {
            return Task.FromResult(_readings);
        }
    }
    
    [TestFixture]
    public class When_analyzing_temperature_readings
    {
        private Result _result;

        [SetUp]
        public async Task Setup()
        {
            var analyzer = new Analyzer(new TestProvider(new List<TemperatureReading>
            {
                new(new DateTime(2021, 01, 01, 01, 00, 00), 5m),
                new(new DateTime(2021, 01, 02, 09, 00, 00), 10m),
                new(new DateTime(2021, 01, 03, 04, 00, 00), 6m),
            }));
            _result = await analyzer.Analyze();
        }

        [Test]
        public void Should_return_average_temperature()
        {
            _result.Average.Should().Be(7m);
        }
        
        [Test]
        public void Should_return_average_night_temperature()
        {
            _result.NightAverage.Should().Be(5.5m);
        }
        
        [Test]
        public void Should_return_average_day_temperature()
        {
            _result.DayAverage.Should().Be(10m);
        }

        [Test]
        public void Should_return_reading_with_highest_temperature()
        {
            _result.Highest.Should().Be(new TemperatureReading(new DateTime(2021, 01, 02, 09, 00, 00), 10m));
        }
        
        [Test]
        public void Should_return_reading_with_lowest_temperature()
        {
            _result.Lowest.Should().Be(new TemperatureReading(new DateTime(2021, 01, 01, 01, 00, 00), 5m));
        }

        [Test]
        public void Should_return_number_of_readings_used()
        {
            _result.NumberOfReadings.Should().Be(3);
        }
    }
}