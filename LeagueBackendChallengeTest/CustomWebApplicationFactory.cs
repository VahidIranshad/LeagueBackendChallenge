using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace LeagueBackendChallengeTest
{
    public class CustomWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        /// <summary>
        /// Create Custome Configure Service For Creating client and Set Logger
        /// </summary>
        /// <param name="builder"></param>
        public void CustomConfigureServices(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                // Get service provider.
                var serviceProvider = services.BuildServiceProvider();

                using (var scope = serviceProvider.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;

                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                }
            });
        }
    }

}
