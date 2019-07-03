using System;

namespace Pixey.Domain.Diagnostics.Events
{
    public abstract class EventBase
    {
        public ClientInfo ClientInfo { get; }

        public DateTimeOffset Timestamp { get; }

        protected EventBase(ClientInfo clientInfo, DateTimeOffset timestamp)
        {
            ClientInfo = clientInfo;
            Timestamp = timestamp;
        }
    }
}
