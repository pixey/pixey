using System.Threading.Tasks;
using Pixey.Domain.Diagnostics.Events;

namespace Pixey.Domain.Diagnostics
{
    public interface ILogService
    {
        Task LogEvent(EventBase evt);
    }
}