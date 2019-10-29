using Edge.Exago.Application.EventSourcedNormalizers;
using Edge.Exago.Application.ViewModels;
using System;
using System.Collections.Generic;

namespace Edge.Exago.Application.Interfaces
{
    public interface ICategoryAppService : IDisposable
    {
        void Register(CategoryViewModel categoryViewModel);
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel GetById(Guid id);
        void Update(CategoryViewModel categoryViewModel);
        void AddNewProduct(ProductViewModel productViewModel);
        IList<CategoryHistoryData> GetAllHistory(Guid id);
    }
}
