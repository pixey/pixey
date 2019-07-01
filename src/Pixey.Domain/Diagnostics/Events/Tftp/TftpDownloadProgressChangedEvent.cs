using System;

namespace Pixey.Domain.Diagnostics.Events.Tftp
{
    public class TftpDownloadProgressChangedEvent : TftpDownloadEventBase
    {
        public string FileName { get; }

        public long TotalBytes { get; }

        public long TransferredBytes { get; }

        public TftpDownloadProgressChangedEvent(
            ClientInfo clientInfo,
            DateTimeOffset timestamp,
            Guid transferId,
            string fileName,
            long totalBytes,
            long transferredBytes)
            : base(clientInfo, timestamp, transferId)
        {
            FileName = fileName;
            TotalBytes = totalBytes;
            TransferredBytes = transferredBytes;
        }
    }
}