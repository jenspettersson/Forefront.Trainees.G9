using System.Net.Http;

namespace FFCG.G9.DependencyInjection.Api.Tests
{
    public abstract class TestBase
    {
        private CustomWebApplicationFactory<Startup> _factory;
        protected readonly HttpClient HttpClient;
        
        protected TestBase()
        {
            _factory = new CustomWebApplicationFactory<Startup>();
            HttpClient = _factory.CreateClient();  
        }
    }
}