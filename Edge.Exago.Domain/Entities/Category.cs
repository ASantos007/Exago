using Edge.Exago.Domain.Core.Models;
using System;
using System.Collections.Generic;

namespace Edge.Exago.Domain.Entities
{
    public class Category : Entity
    {
        public Category(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public List<Product> Products { get; private set; }

        internal void AddProduct(Product product)
        {
            if(Products == null)
            {
                Products = new List<Product>();
            }

            Products.Add(product);
        }
    }
}
