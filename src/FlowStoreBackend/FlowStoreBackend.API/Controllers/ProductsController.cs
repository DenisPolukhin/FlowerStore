using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.Page;
using FlowStoreBackend.Logic.Models.Product;
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

        [Authorize(Policy = "Administrator")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductModel createProductModel)
        {
            await _productService.CreateAsync(createProductModel);
            return NoContent();
        }

        [Authorize(Policy = "Administrator")]
        [HttpPatch("{id:guid}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductModel updateProductModel)
        {
            await _productService.UpdateAsync(id, updateProductModel);
            return NoContent();
        }

        [Authorize(Policy = "Administrator")]
        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
