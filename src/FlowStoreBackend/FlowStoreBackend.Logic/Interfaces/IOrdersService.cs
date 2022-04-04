using FlowStoreBackend.Logic.Models.Order;

namespace FlowStoreBackend.Logic.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderModel>> GetOrdersAsync(Guid userId);
        Task<PaymentReference> CreateOrderAsync(Guid userId, CreateOrderModel products);
    }
}
