using Microsoft.Extensions.DependencyInjection;
using Pixey.Domain.Diagnostics.Troubleshooting;
using Pixey.Website.Caching;
using Pixey.Website.Services;
using Pixey.Website.Services.Troubleshooting;

namespace Pixey.Website
{
    public static class ContainerRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ISlidingExpirationMemoryStore<ITroubleshooter>, SlidingExpirationMemoryStore<ITroubleshooter>>();
            services.AddSingleton< ISlidingExpirationMemoryStoreFactory, SlidingExpirationMemoryStoreFactory>();

            services.AddSingleton<ITroubleshootingService, TroubleshootingService>();

            return services;
        }
    }
}