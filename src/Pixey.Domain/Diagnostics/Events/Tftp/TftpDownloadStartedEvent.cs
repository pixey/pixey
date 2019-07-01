using System;

namespace Pixey.Domain.Diagnostics.Events.Tftp
{
    public class TftpDownloadStartedEvent : TftpDownloadEventBase
    {
        public string FileName { get; }

        public TftpDownloadStartedEvent(
            ClientInfo clientInfo,
            DateTimeOffset timestamp,
            Guid transferId,
            string fileName)
            : base(clientInfo, timestamp, transferId)
        {
            FileName = fileName;
        }
    }
}