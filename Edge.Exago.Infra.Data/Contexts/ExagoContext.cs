using Edge.Exago.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Edge.Exago.Infra.Data.Contexts
{
    public class ExagoContext : DbContext
    {
        public ExagoContext(DbContextOptions<ExagoContext> options)
           : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
