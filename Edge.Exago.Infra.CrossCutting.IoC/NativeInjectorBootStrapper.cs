using Edge.Exago.Application.Interfaces;
using Edge.Exago.Application.Services;
using Edge.Exago.Domain.CommandHandlers;
using Edge.Exago.Domain.Commands;
using Edge.Exago.Domain.Core.Bus;
using Edge.Exago.Domain.Core.Events;
using Edge.Exago.Domain.Core.Notifications;
using Edge.Exago.Domain.EventHandlers;
using Edge.Exago.Domain.Events;
using Edge.Exago.Domain.Interfaces;
using Edge.Exago.Infra.CrossCutting.Bus;
using Edge.Exago.Infra.Data.Contexts;
using Edge.Exago.Infra.Data.EventSourcing;
using Edge.Exago.Infra.Data.Repositories;
using Edge.Exago.Infra.Data.Repositories.EventSourcing;
using Edge.Exago.Infra.Data.UoW;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Edge.Exago.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ICategoryAppService, CategoryAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<INotificationHandler<CategoryRegisteredEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<CategoryUpdatedEvent>, CategoryEventHandler>();
            services.AddScoped<INotificationHandler<NewProductAddedEvent>, CategoryEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCategoryCommand, bool>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCategoryCommand, bool>, CategoryCommandHandler>();
            services.AddScoped<IRequestHandler<AddNewProductCommand, bool>, CategoryCommandHandler>();

            // Infra - Data
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ExagoContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStore, SqlEventStore>();
            services.AddScoped<EventStoreSQLContext>();
        }
    }
}