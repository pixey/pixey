using Microsoft.Extensions.DependencyInjection;
using Pixey.Domain.BootLoaders;
using Pixey.Domain.Diagnostics;

namespace Pixey.Domain
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddSingleton<ILogService, LogService>();
            services.AddSingleton<IBootLoaderService, BootLoaderService>();

            return services;
        }
    }
}