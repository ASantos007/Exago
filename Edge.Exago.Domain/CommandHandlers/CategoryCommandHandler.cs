using Edge.Exago.Domain.Commands;
using Edge.Exago.Domain.Core.Bus;
using Edge.Exago.Domain.Core.Notifications;
using Edge.Exago.Domain.Entities;
using Edge.Exago.Domain.Events;
using Edge.Exago.Domain.Interfaces;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Edge.Exago.Domain.CommandHandlers
{
    public class CategoryCommandHandler : CommandHandler,
        IRequestHandler<RegisterNewCategoryCommand, bool>,
        IRequestHandler<UpdateCategoryCommand, bool>,
        IRequestHandler<AddNewProductCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMediatorHandler Bus;

        public CategoryCommandHandler(ICategoryRepository categoryRepository,
                                      IUnitOfWork uow,
                                      IMediatorHandler bus,
                                      INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            _categoryRepository = categoryRepository;
            Bus = bus;
        }

        public Task<bool> Handle(RegisterNewCategoryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            Category category = new Category(Guid.NewGuid(), message.Name);

            if (_categoryRepository.GetByName(category.Name) != null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Category Name has already been taken."));
                return Task.FromResult(false);
            }

            _categoryRepository.Add(category);

            if (Commit())
            {
                Bus.RaiseEvent(new CategoryRegisteredEvent(category.Id, category.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCategoryCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            Category category = new Category(message.Id, message.Name);

            Category existingcategory = _categoryRepository.GetById(category.Id);

            if (existingcategory == null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Category does not exist."));
                return Task.FromResult(false);
            }

            if (existingcategory.Id != category.Id)
            {
                if (!existingcategory.Equals(category))
                {
                    Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Category Name has already been taken."));
                    return Task.FromResult(false);
                }
            }

            _categoryRepository.Update(category);

            if (Commit())
            {
                Bus.RaiseEvent(new CategoryUpdatedEvent(category.Id, category.Name));
            }

            return Task.FromResult(true);
        }

        public Task<bool> Handle(AddNewProductCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            #region Get Category

            Category existingcategory = _categoryRepository.GetById(message.Id);

            if (existingcategory == null)
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Category does not exist."));
                return Task.FromResult(false);
            }

            #endregion Get Category

            #region Add Product to Category

            Product product = new Product(Guid.NewGuid(), message.Name);

            if (existingcategory.Products != null && existingcategory.Products.Any(p => p.Name == product.Name))
            {
                Bus.RaiseEvent(new DomainNotification(message.MessageType, "The Product Name has already been taken."));
                return Task.FromResult(false);
            }

            existingcategory.AddProduct(product);

            #endregion Add Product to Category

            _categoryRepository.Update(existingcategory);

            if (Commit())
            {
                Bus.RaiseEvent(new NewProductAddedEvent(existingcategory.Id, existingcategory.Name));
            }

            return Task.FromResult(true);
        }

        public void Dispose()
        {
            _categoryRepository.Dispose();
        }
    }
}