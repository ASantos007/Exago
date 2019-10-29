using System;
using Edge.Exago.Application.Interfaces;
using Edge.Exago.Application.ViewModels;
using Edge.Exago.Domain.Core.Bus;
using Edge.Exago.Domain.Core.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Edge.Exago.WebApi.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly ICategoryAppService _categoryAppService;

        public CategoryController(ICategoryAppService categoryAppService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator) 
            : base(notifications, mediator)
        {
            _categoryAppService = categoryAppService;
        }

        [HttpGet]
        [Route("category-getall")]
        public IActionResult GetAll()
        {
            return Response(_categoryAppService.GetAll());
        }

        [HttpGet]
        [Route("category-get/{id:guid}")]
        public IActionResult Get(Guid id)
        {
            var categoryViewModel = _categoryAppService.GetById(id);

            return Response(categoryViewModel);
        }

        [HttpPost]
        [Route("category-register")]
        public IActionResult Register([FromBody]CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(categoryViewModel);
            }

            _categoryAppService.Register(categoryViewModel);

            return Response(categoryViewModel);
        }

        [HttpPut]
        [Route("category-update")]
        public IActionResult Update([FromBody]CategoryViewModel categoryViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(categoryViewModel);
            }

            _categoryAppService.Update(categoryViewModel);

            return Response(categoryViewModel);
        }

        [HttpPost]
        [Route("category-addNewProduct")]
        public IActionResult AddNewProduct([FromBody]ProductViewModel productViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(productViewModel);
            }

            _categoryAppService.AddNewProduct(productViewModel);

            return Response(productViewModel);
        }

        [HttpGet]
        [Route("category-management/history/{id:guid}")]
        public IActionResult History(Guid id)
        {
            var categoryHistoryData = _categoryAppService.GetAllHistory(id);
            return Response(categoryHistoryData);
        }
    }
}
