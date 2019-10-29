using AutoMapper;
using AutoMapper.QueryableExtensions;
using Edge.Exago.Application.EventSourcedNormalizers;
using Edge.Exago.Application.Interfaces;
using Edge.Exago.Application.ViewModels;
using Edge.Exago.Domain.Commands;
using Edge.Exago.Domain.Core.Bus;
using Edge.Exago.Domain.Interfaces;
using Edge.Exago.Infra.Data.Repositories.EventSourcing;
using System;
using System.Collections.Generic;

namespace Edge.Exago.Application.Services
{
    public class CategoryAppService : ICategoryAppService
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IEventStoreRepository _eventStoreRepository;
        private readonly IMediatorHandler _bus;

        public CategoryAppService(IMapper mapper, ICategoryRepository categoryRepository, IMediatorHandler bus, IEventStoreRepository eventStoreRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
            _bus = bus;
            _eventStoreRepository = eventStoreRepository;
        }

        public IEnumerable<CategoryViewModel> GetAll()
        {
            return _categoryRepository.GetAll().ProjectTo<CategoryViewModel>(_mapper.ConfigurationProvider);
        }

        public CategoryViewModel GetById(Guid id)
        {
            return _mapper.Map<CategoryViewModel>(_categoryRepository.GetById(id));
        }

        public void Register(CategoryViewModel categoryViewModel)
        {
            RegisterNewCategoryCommand registerCommand = _mapper.Map<RegisterNewCategoryCommand>(categoryViewModel);
            _bus.SendCommand(registerCommand);
        }

        public void Update(CategoryViewModel categoryViewModel)
        {
            UpdateCategoryCommand updateCommand = _mapper.Map<UpdateCategoryCommand>(categoryViewModel);
            _bus.SendCommand(updateCommand);
        }

        public void AddNewProduct(ProductViewModel productViewModel)
        {
            AddNewProductCommand addNewProductCommand = _mapper.Map<AddNewProductCommand>(productViewModel);
            _bus.SendCommand(addNewProductCommand);
        }

        public IList<CategoryHistoryData> GetAllHistory(Guid id)
        {
            return CategoryHistory.ToJavaScriptCategoryHistory(_eventStoreRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
