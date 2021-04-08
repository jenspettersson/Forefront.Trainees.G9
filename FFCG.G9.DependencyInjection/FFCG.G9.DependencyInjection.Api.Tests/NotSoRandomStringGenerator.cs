using FFCG.G9.DependencyInjection.Api.Features.Random;

namespace FFCG.G9.DependencyInjection.Api.Tests
{
    public class NotSoRandomStringGenerator : IStringGenerator
    {
        public string GetString()
        {
            return "WELL KNOWN";
        }
    }
}