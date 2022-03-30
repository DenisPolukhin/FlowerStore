using AutoMapper;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Models.Product;

namespace FlowStoreBackend.Logic.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductModel>();
        }
    }
}
