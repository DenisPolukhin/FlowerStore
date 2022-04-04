using FlowStoreBackend.Logic.Models.Order;

namespace FlowStoreBackend.Logic.Interfaces
{
    public interface IPaymentsService
    {
        Task<string> CreatePaidOrderUrl(PaidOrderUrlModel createPaidOrderUrlModel);
    }
}
