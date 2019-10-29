using Edge.Exago.Domain.Core.Events;
using Edge.Exago.Infra.Data.Repositories.EventSourcing;
using Newtonsoft.Json;

namespace Edge.Exago.Infra.Data.EventSourcing
{
    public class SqlEventStore : IEventStore
    {
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStore(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "ASantos");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}