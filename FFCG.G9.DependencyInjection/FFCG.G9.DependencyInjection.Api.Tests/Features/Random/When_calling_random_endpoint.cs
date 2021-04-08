using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using FFCG.G9.DependencyInjection.Api.Features.Random;
using FluentAssertions;
using NUnit.Framework;

namespace FFCG.G9.DependencyInjection.Api.Tests.Features.Random
{
    [TestFixture]
    public class When_calling_random_endpoint : TestBase
    {
        private string _result;

        [OneTimeSetUp]
        public async Task OneTimeSetup()
        {
            _result = await HttpClient.GetStringAsync("/random");
        }

        [Test]
        public void The_generated_string_should_be_returned()
        {
            _result.Should().Be("WELL KNOWN");
        }
    }
}