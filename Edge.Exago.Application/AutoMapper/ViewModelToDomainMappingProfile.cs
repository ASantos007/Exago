using AutoMapper;
using Edge.Exago.Application.ViewModels;
using Edge.Exago.Domain.Commands;

namespace Edge.Exago.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<CategoryViewModel, RegisterNewCategoryCommand>()
               .ConstructUsing(c => new RegisterNewCategoryCommand(c.Name));

            CreateMap<CategoryViewModel, UpdateCategoryCommand>()
                .ConstructUsing(c => new UpdateCategoryCommand(c.Id, c.Name));

            CreateMap<ProductViewModel, AddNewProductCommand>()
                .ConstructUsing(c => new AddNewProductCommand(c.CategoryId, c.Name));
        }
    }
}
