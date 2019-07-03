using Microsoft.Extensions.DependencyInjection;
using Pixey.Domain.Diagnostics;

namespace Pixey.Storage
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddStorage(this IServiceCollection services)
        {
            services.AddSingleton<ILogEventRepository, LogEventRepository>();

            return services;
        }
    }
}
