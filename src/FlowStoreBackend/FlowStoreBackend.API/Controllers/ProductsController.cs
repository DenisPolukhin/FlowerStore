using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.Page;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FlowStoreBackend.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;
        public ProductsController(IProductsService productsService)
        {
            _productService = productsService;
        }

        private Guid UserId => Guid.ParseExact(User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value, "D");

        [AllowAnonymous]
        [HttpGet("category/{categoryId:guid}")]
        public async Task<IActionResult> GetCategoryProductAsync(Guid categoryId, [FromQuery] PageModel pageModel)
        {
            var result = await _productService.GetCategoryProductAsync(categoryId, pageModel);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetDetails(Guid id)
        {
            var result = await _productService.GetDetailsAsync(id);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Search(string searchText, [FromQuery] PageModel pageModel)
        {
            var result = await _productService.SearchAsync(searchText, pageModel);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var result = await _productService.GetCategoriesAsync();
            return Ok(result);
        }
    }
}
