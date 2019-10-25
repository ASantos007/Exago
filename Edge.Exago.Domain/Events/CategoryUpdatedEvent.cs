using Edge.Exago.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Edge.Exago.Domain.Events
{
    public class CategoryUpdatedEvent : Event
    {
        public CategoryUpdatedEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }
    }
}
