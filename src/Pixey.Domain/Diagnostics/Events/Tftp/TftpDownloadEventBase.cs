using System;

namespace Pixey.Domain.Diagnostics.Events.Tftp
{
    public abstract class TftpDownloadEventBase : EventBase
    {
        public Guid TransferId { get; }

        protected TftpDownloadEventBase(
            ClientInfo clientInfo,
            DateTimeOffset timestamp,
            Guid transferId)
            : base(clientInfo, timestamp)
        {
            TransferId = transferId;
        }
    }
}