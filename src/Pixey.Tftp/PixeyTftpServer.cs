using System;
using System.Net;
using Microsoft.Extensions.Logging;
using Tftp.Net;

namespace Pixey.Tftp
{
    public class PixeyTftpServer : IPixeyTftpServer, IDisposable
    {
        private readonly IPixeyTftpTransferFactory _transferFactory;
        private readonly ILogger<PixeyTftpServer> _logger;
        private readonly TftpServer _tftpServer;

        public PixeyTftpServer(
            IPixeyTftpTransferFactory transferFactory, 
            ILogger<PixeyTftpServer> logger)
        {
            _transferFactory = transferFactory;
            _logger = logger;

            _tftpServer = new TftpServer();
            _tftpServer.OnWriteRequest += HandleWriteRequest;
            _tftpServer.OnReadRequest += HandleReadRequest;
            _tftpServer.OnError += HandleError;
        }

        public void Start()
        {
            _tftpServer.Start();
        }

        public void Dispose()
        {
            _tftpServer.Dispose();
        }

        private void HandleWriteRequest(ITftpTransfer transfer, EndPoint client)
        {
            _logger.LogInformation("Write request attempted on TFTP server from {0}. Cancelling request.", client?.AddressFamily);

            transfer.Cancel(TftpErrorPacket.IllegalOperation);
        }

        private void HandleReadRequest(ITftpTransfer transfer, EndPoint client)
        {
            var pixeyTransfer = _transferFactory.CreateTftpTransfer(transfer, client);

            pixeyTransfer.Process();
        }

        private void HandleError(TftpTransferError error)
        {
            _logger.LogError("Error occured in TFTP server: {0}", error.ToString());
        }
    }
}
