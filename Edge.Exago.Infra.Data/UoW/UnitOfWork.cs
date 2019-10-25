using Edge.Exago.Domain.Interfaces;
using Edge.Exago.Infra.Data.Contexts;

namespace Edge.Exago.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ExagoContext _context;

        public UnitOfWork(ExagoContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}