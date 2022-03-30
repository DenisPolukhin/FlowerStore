using FlowStoreBackend.Common.Pagination;
using FlowStoreBackend.Logic.Models.Category;
using FlowStoreBackend.Logic.Models.Page;
using FlowStoreBackend.Logic.Models.Product;

namespace FlowStoreBackend.Logic.Interfaces
{
    public interface IProductsService
    {
        Task<ProductModel> GetDetailsAsync(Guid id);
        Task<IPaginatedList<ProductModel>> GetCategoryProductAsync(Guid categoryId, PageModel pageModel);
        Task<IPaginatedList<ProductModel>> SearchAsync(string searchText, PageModel pageModel);

        Task<IEnumerable<CategoryModel>> GetCategoriesAsync();

        Task<ProductModel> CreateAsync(CreateProductModel createProductModel);
        Task<ProductModel> UpdateAsync(Guid id, UpdateProductModel updateProductModel);
        Task DeleteAsync(Guid id);
    }
}
