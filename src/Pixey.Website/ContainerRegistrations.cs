using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Pixey.Domain.Diagnostics.Troubleshooting;
using Pixey.Website.Caching;
using Pixey.Website.Middlewares;
using Pixey.Website.Services.Troubleshooting;
using Pixey.Website.SignalHubs;

namespace Pixey.Website
{
    public static class ContainerRegistrations
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddSingleton<ISlidingExpirationMemoryStore<ITroubleshooter>, SlidingExpirationMemoryStore<ITroubleshooter>>();
            services.AddSingleton<ISlidingExpirationMemoryStoreFactory, SlidingExpirationMemoryStoreFactory>();

            services.AddSingleton<ITroubleshootingService, TroubleshootingService>();

            return services;
        }

        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            services.AddSingleton<SignInUserMiddleware>();

            return services;
        }

        public static IServiceCollection AddSignalrHelpers(this IServiceCollection services)
        {
            services.AddSingleton<IUserIdProvider, RequestIdentityUserIdProvider>();

            return services;
        }
    }
}