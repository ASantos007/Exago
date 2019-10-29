using AutoMapper;
using Edge.Exago.Application.ViewModels;
using Edge.Exago.Domain.Entities;

namespace Edge.Exago.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Category, CategoryViewModel>();
            CreateMap<Product, ProductViewModel>();
        }
    }
}
