using System;

namespace FFCG.G9.DependencyInjection.Api.Features.Random
{
    public class RandomStringGenerator : IStringGenerator
    {
        private readonly string _str;

        public RandomStringGenerator()
        {
            var randomString = Guid.NewGuid().ToString("N");
            _str = $"{DateTime.Now} - {randomString}";
        }
        
        public string GetString()
        {
            return _str;
        }
    }
}