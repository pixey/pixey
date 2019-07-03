using Microsoft.Extensions.DependencyInjection;
using Pixey.Domain.BootLoaders;
using Pixey.Domain.Diagnostics;
using Pixey.Domain.Diagnostics.Troubleshooting;

namespace Pixey.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<IClock, Clock>();

            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<IBootLoaderService, BootLoaderService>();

            services.AddSingleton<ITroubleshooter, Troubleshooter>();
            services.AddSingleton<ITroubleshooterFactory, TroubleshooterFactory>();

            return services;
        }
    }
}