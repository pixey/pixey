using System.Net;
using Microsoft.Extensions.Logging;
using Pixey.Domain;
using Pixey.Domain.BootLoaders;
using Pixey.Domain.Diagnostics;
using Tftp.Net;

namespace Pixey.Tftp
{
    internal class PixeyTftpTransferFactory : IPixeyTftpTransferFactory
    {
        private readonly IClock _clock;
        private readonly ILogService _logService;
        private readonly IBootLoaderService _bootLoaderService;
        private readonly ILoggerFactory _loggerFactory;

        public PixeyTftpTransferFactory(
            IClock clock,
            ILogService logService, 
            IBootLoaderService bootLoaderService,
            ILoggerFactory loggerFactory)
        {
            _clock = clock;
            _logService = logService;
            _bootLoaderService = bootLoaderService;
            _loggerFactory = loggerFactory;
        }

        public IPixeyTftpTransfer CreateTftpTransfer(ITftpTransfer underlyingTransfer, EndPoint client)
        {
            var logger = _loggerFactory.CreateLogger<PixeyTftpTransfer>();

            return new PixeyTftpTransfer(
                underlyingTransfer, 
                client, 
                _logService, 
                _bootLoaderService,
                _clock,
                logger);
        }
    }
}