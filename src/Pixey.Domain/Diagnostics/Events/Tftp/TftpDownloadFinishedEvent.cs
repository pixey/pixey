using System;

namespace Pixey.Domain.Diagnostics.Events.Tftp
{
    public class TftpDownloadFinishedEvent : TftpDownloadEventBase
    {
        public string FileName { get; }

        public TftpDownloadFinishedEvent(
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