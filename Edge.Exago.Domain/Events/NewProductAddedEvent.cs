using Edge.Exago.Domain.Core.Events;
using System;

namespace Edge.Exago.Domain.Events
{
    public class NewProductAddedEvent : Event
    {
        public NewProductAddedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }
    }
}
