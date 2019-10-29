using AutoMapper;
using Edge.Exago.Application.ViewModels;
using Edge.Exago.Domain.Entities;

namespace Edge.Exago.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>()
               .ConstructUsing(c => new CategoryViewModel
               {
                   Id = c.Id,
                   Name = c.Name,
               });

            CreateMap<Product, ProductViewModel>();
        }
    }
}
