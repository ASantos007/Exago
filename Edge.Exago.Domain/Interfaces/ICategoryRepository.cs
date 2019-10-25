using Edge.Exago.Domain.Entities;

namespace Edge.Exago.Domain.Interfaces
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Category GetByName(string name);
    }
}