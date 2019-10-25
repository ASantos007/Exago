using Edge.Exago.Domain.Core.Commands;
using Edge.Exago.Domain.Core.Events;
using System.Threading.Tasks;

namespace Edge.Exago.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
