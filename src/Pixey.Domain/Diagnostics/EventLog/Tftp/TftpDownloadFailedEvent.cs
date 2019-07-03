using System;

namespace Pixey.Domain.Diagnostics.Events.Tftp
{
    public class TftpDownloadFailedEvent : TftpDownloadEventBase
    {
        public string FileName { get; }

        public string Error { get; }

        public TftpDownloadFailedEvent(
            ClientInfo clientInfo,
            DateTimeOffset timestamp,
            Guid transferId,
            string fileName,
            string error)
            : base(clientInfo, timestamp, transferId)
        {
            FileName = fileName;
            Error = error;
        }
    }
}