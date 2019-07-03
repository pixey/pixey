using System.Threading.Tasks;
using Pixey.Domain.Diagnostics.Events;

namespace Pixey.Domain.Diagnostics
{
    public class LogService : ILogService
    {
        private readonly ILogEventRepository _repository;

        public LogService(ILogEventRepository repository)
        {
            _repository = repository;
        }

        public Task LogEvent(EventBase evt)
        {
            return _repository.StoreEvent(evt);
        }
    }
}
