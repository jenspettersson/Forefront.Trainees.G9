using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G9.TemperatureAnalyzer.Tests
{
    [TestFixture]
    public class When_analying_temperature_readings_with_multiple_of_same_value
    {
        private Result _result;

        [SetUp]
        public async Task Setup()
        {
            var analyzer = new Analyzer(new TestProvider(new List<TemperatureReading>
            {
                new(new DateTime(2021, 01, 03), 5m),
                new(new DateTime(2021, 01, 04), 10m),
                new(new DateTime(2021, 01, 01), 5m),
                new(new DateTime(2021, 01, 02), 10m)
            }));
            _result = await analyzer.Analyze();
        }

        [Test]
        public void First_date_with_lowest_value_should_be_lowest()
        {
            _result.Lowest.Should().Be(new TemperatureReading(new DateTime(2021, 01, 01), 5m));
        }
        
        [Test]
        public void First_date_with_highest_value_should_be_highest()
        {
            _result.Highest.Should().Be(new TemperatureReading(new DateTime(2021, 01, 02), 10m));
        }
    }
}