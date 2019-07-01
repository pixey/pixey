using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Pixey.Tftp
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTftp(this IServiceCollection services)
        {
            services.AddSingleton<IHostedService, PixeyTftpServerHost>();
            services.AddSingleton<ITftpServerFactory, TftpServerFactory>();

            services.AddSingleton<IPixeyTftpServer, PixeyTftpServer>();
            services.AddSingleton<IPixeyTftpTransferFactory, PixeyTftpTransferFactory>();

            return services;
        }
    }
}