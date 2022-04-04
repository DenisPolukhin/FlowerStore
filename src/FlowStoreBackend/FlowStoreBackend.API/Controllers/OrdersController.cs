using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.Order;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowStoreBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrdersService _ordersService;
        public OrdersController(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }

        private Guid UserId => Guid.ParseExact(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value, "D");

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            var result = await _ordersService.GetOrdersAsync(UserId);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateOrderModel createOrderModel)
        {
            var result = await _ordersService.CreateOrderAsync(UserId, createOrderModel);
            return Ok(result);
        }
    }
}
