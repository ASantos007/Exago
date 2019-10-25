using Edge.Exago.Domain.Events;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Edge.Exago.Domain.EventHandlers
{
    public class CategoryEventHandler :
        INotificationHandler<CategoryRegisteredEvent>,
        INotificationHandler<CategoryUpdatedEvent>,
        INotificationHandler<NewProductAddedEvent>
    {
        public Task Handle(CategoryRegisteredEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail or do another thing

            return Task.CompletedTask;
        }

        public Task Handle(CategoryUpdatedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail or another thing

            return Task.CompletedTask;
        }

        public Task Handle(NewProductAddedEvent message, CancellationToken cancellationToken)
        {
            // Send some notification e-mail or do another thing

            return Task.CompletedTask;
        }
    }
}