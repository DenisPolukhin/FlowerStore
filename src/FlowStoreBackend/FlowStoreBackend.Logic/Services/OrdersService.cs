using AutoMapper;
using FlowStoreBackend.Database.Models;
using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.Order;
using Microsoft.EntityFrameworkCore;

namespace FlowStoreBackend.Logic.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public OrdersService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync(Guid userId)
        {
            var orders = await _databaseContext.Orders
                .Where(x => x.UserId == userId)
                .Include(x => x.Products)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }
    }
}
