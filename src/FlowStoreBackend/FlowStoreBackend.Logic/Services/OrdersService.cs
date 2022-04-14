using AutoMapper;
using FlowStoreBackend.Common.Exceptions;
using FlowStoreBackend.Database.Models;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.Order;
using FlowStoreBackend.Logic.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace FlowStoreBackend.Logic.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IPaymentsService _paymentsService;
        private readonly IMapper _mapper;
        public OrdersService(DatabaseContext databaseContext, IPaymentsService paymentsService,
            IMapper mapper)
        {
            _databaseContext = databaseContext;
            _paymentsService = paymentsService;
            _mapper = mapper;
        }

        public async Task<PaymentReference> CreateOrderAsync(Guid userId, CreateOrderModel orderModel)
        {
            var user = await _databaseContext.Users.FindAsync(userId);
            if (user == null)
            {
                throw new EntityFindException();
            }

            var products = await _databaseContext.Products
                .Where(p => orderModel.Products.Select(x => x.Id).Contains(p.Id))
                .ToListAsync();

            if (products.Count() != orderModel.Products.Select(x => x.Id).Count())
            {
                throw new InvalidOperationException();
            }

            var productsInOrder = orderModel.Products.Select(x => new ProductInOrder
            {
                ProductId = x.Id,
                Quantity = x.Quantity
            }).ToList();

            var order = new Order
            {
                User = user,
                ProductsInOrder = productsInOrder
            };

            await _databaseContext.Orders.AddAsync(order);
            var paidOrderModel = new PaidOrderUrlModel
            {
                Id = order.Id,
                UserEmail = order.User.Email,
                UserPhoneNumber = order.User.PhoneNumber,
                Products = order.ProductsInOrder.Select(x => new PaidProductModel
                {
                    Id = x.ProductId,
                    Name = x.Product.Name,
                    UnitPrice = x.Product.Price,
                    TotalPrice = x.Product.Price * x.Quantity,
                    Quantity = x.Quantity
                })
            };

            var paymentUrl = await _paymentsService.CreatePaidOrderUrl(paidOrderModel);
            await _databaseContext.SaveChangesAsync();

            return new PaymentReference(order.Id, paymentUrl);
        }

        public async Task<IEnumerable<OrderModel>> GetOrdersAsync(Guid userId)
        {
            var orders = await _databaseContext.Orders
                .Where(x => x.UserId == userId && x.Payment.PaidAt.HasValue)
                .Include(x => x.ProductsInOrder)
                .ToListAsync();

            return _mapper.Map<IEnumerable<OrderModel>>(orders);
        }
    }
}
