using Edge.Exago.Domain.Core.Models;
using System;

namespace Edge.Exago.Domain.Entities
{
    public class Product : Entity
    {
        public Product(Guid id,  string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }
    }
}
