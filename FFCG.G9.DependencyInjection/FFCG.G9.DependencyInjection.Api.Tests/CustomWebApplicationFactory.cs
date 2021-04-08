using System.Linq;
using FFCG.G9.DependencyInjection.Api.Features.Random;
using FFCG.G9.DependencyInjection.Api.Tests.Features.Random;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FFCG.G9.DependencyInjection.Api.Tests
{
    public class CustomWebApplicationFactory<TStartup>
        : WebApplicationFactory<TStartup> where TStartup: class
    {

        protected override IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                RemoveService<IStringGenerator>(services);
                
                services.AddSingleton<IStringGenerator, NotSoRandomStringGenerator>();
            });
        }

        private void RemoveService<T>(IServiceCollection services)
        {
            var descriptor = services.SingleOrDefault(
                d => d.ServiceType == typeof(T));

            services.Remove(descriptor);
        }
    }
}