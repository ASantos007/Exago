using Edge.Exago.Domain.Core.Commands;
using System;

namespace Edge.Exago.Domain.Commands
{
    public abstract class CategoryCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }
    }
}