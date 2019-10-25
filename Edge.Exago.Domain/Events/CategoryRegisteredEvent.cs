﻿using Edge.Exago.Domain.Core.Events;
using System;

namespace Edge.Exago.Domain.Events
{
    public class CategoryRegisteredEvent : Event
    {
        public CategoryRegisteredEvent(Guid id, string name)
        {
            Id = id;
            Name = name;
            AggregateId = id;
        }

        public Guid Id { get; set; }

        public string Name { get; private set; }
    }
}
