using System;
using System.Threading.Tasks;
using Pixey.Domain.Diagnostics;
using Pixey.Domain.Diagnostics.Events;

namespace Pixey.Storage
{
    public class LogEventRepository : ILogEventRepository
    {
        public Task StoreEvent(EventBase evt)
        {
            throw new NotImplementedException();
        }
    }
}
