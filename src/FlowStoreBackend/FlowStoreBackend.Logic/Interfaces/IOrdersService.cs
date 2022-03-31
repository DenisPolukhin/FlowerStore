using FlowStoreBackend.Common.Pagination;
using FlowStoreBackend.Logic.Models.Order;

namespace FlowStoreBackend.Logic.Interfaces
{
    public interface IOrdersService
    {
        Task<IEnumerable<OrderModel>> GetOrdersAsync(Guid userId);
    }
}
