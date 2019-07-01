using System;
using System.Net;
using Microsoft.Extensions.Logging;
using Pixey.Domain;
using Pixey.Domain.BootLoaders;
using Pixey.Domain.BootLoaders.Exceptions;
using Pixey.Domain.Diagnostics;
using Pixey.Domain.Diagnostics.Events;
using Pixey.Domain.Diagnostics.Events.Tftp;
using Tftp.Net;

namespace Pixey.Tftp
{
    internal class PixeyTftpTransfer : IPixeyTftpTransfer
    {
        private readonly ITftpTransfer _transfer;
        private readonly ILogService _logService;
        private readonly IBootLoaderService _bootLoaderService;
        private readonly IClock _clock;
        private readonly ILogger<PixeyTftpTransfer> _logger;
        private readonly Guid _transferId;
        private readonly ClientInfo _clientInfo;

        public PixeyTftpTransfer(
            ITftpTransfer transfer,
            EndPoint client,
            ILogService logService,
            IBootLoaderService bootLoaderService,
            IClock clock,
            ILogger<PixeyTftpTransfer> logger)
        {
            _transferId = Guid.NewGuid();

            _transfer = transfer;
            _logService = logService;
            _bootLoaderService = bootLoaderService;
            _clock = clock;
            _logger = logger;

            _clientInfo = new ClientInfo(GetIpAddress(client));

            _transfer.OnError += HandleTransferError;
            _transfer.OnProgress += HandleTransferProgress;
            _transfer.OnFinished += HandleTransferFinished;
        }

        public void Process()
        {
            try
            {
                LogDownloadStarted();

                using (var binaryStream = _bootLoaderService.GetBootLoaderBinary(_transfer.Filename))
                {
                    _transfer.Start(binaryStream);
                }
            }
            catch (InvalidBootLoaderBinaryException)
            {
                LogDownloadFailedWithInvalidFileName();

                _transfer.Cancel(TftpErrorPacket.FileNotFound);
            }
        }

        private void HandleTransferError(ITftpTransfer transfer, TftpTransferError error)
        {
            _logger.LogWarning(
                "Transfer {0} has failed with an error: {1}.",
                _transferId,
                error.ToString());

            var evt = new TftpDownloadFailedEvent(
                _clientInfo, 
                _clock.GetOffsetNow(),
                _transferId,
                transfer.Filename,
                error.ToString());

            _logService.LogEvent(evt);
        }

        private void HandleTransferFinished(ITftpTransfer transfer)
        {
            _logger.LogInformation(
                "Transfer {0} has been finished successfully.",
                _transferId);

            var evt = new TftpDownloadFinishedEvent(
                _clientInfo, 
                _clock.GetOffsetNow(), 
                _transferId,
                transfer.Filename);

            _logService.LogEvent(evt);
        }

        private void HandleTransferProgress(ITftpTransfer transfer, TftpTransferProgress progress)
        {
            _logger.LogDebug(
                "Transfer {0} progress changed to {1}/{2} bytes.", 
                _transferId, 
                progress.TransferredBytes, 
                progress.TotalBytes);

            var evt = new TftpDownloadProgressChangedEvent(
                _clientInfo,
                _clock.GetOffsetNow(),
                _transferId,
                transfer.Filename,
                progress.TotalBytes,
                progress.TransferredBytes);

            _logService.LogEvent(evt);
        }

        private void LogDownloadStarted()
        {
            var evt = new TftpDownloadStartedEvent(
                _clientInfo,
                _clock.GetOffsetNow(),
                _transferId,
                _transfer.Filename);

            _logService.LogEvent(evt);
        }

        private void LogDownloadFailedWithInvalidFileName()
        {
            _logger.LogWarning(
                "Transfer {0} has requested an invalid file name: {1} (Client {2})",
                _transferId,
                _transfer.Filename,
                _clientInfo);

            var evt = new TftpDownloadFailedEvent(
                _clientInfo,
                _clock.GetOffsetNow(),
                _transferId,
                _transfer.Filename,
                "Invalid file name");

            _logService.LogEvent(evt);
        }

        private IPAddress GetIpAddress(EndPoint client)
        {
            if (client is IPEndPoint ipEndpoint)
            {
                return ipEndpoint.Address;
            }

            return null;
        }
    }
}