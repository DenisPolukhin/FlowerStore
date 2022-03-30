using AutoMapper;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Models.Category;

namespace FlowStoreBackend.Logic.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}
