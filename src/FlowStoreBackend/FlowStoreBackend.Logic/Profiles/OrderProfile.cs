using AutoMapper;
using FlowStoreBackend.Common.ValueConverters;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Models.Order;

namespace FlowStoreBackend.Logic.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderModel>()
                .ForMember(ord => ord.CreatedAt, opt => opt.ConvertUsing(new InstantToDateTimeConverter()));
        }
    }
}
