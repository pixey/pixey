using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;

namespace Pixey.Tftp
{
    public class PixeyTftpServerHost : IHostedService
    {
        private readonly IPixeyTftpServer _pixeyTftpServer;

        public PixeyTftpServerHost(IPixeyTftpServer pixeyTftpServer)
        {
            _pixeyTftpServer = pixeyTftpServer;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _pixeyTftpServer.Start();

            return Task.FromResult(0);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _pixeyTftpServer.Dispose();

            return Task.FromResult(0);
        }
    }
}