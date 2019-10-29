using Edge.Exago.Domain.Core.Events;
using Edge.Exago.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Edge.Exago.Infra.Data.Contexts
{
    public class EventStoreSQLContext : DbContext
    {
        public EventStoreSQLContext(DbContextOptions<EventStoreSQLContext> options)
             : base(options)
        {
        }

        public DbSet<StoredEvent> StoredEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StoredEventMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}