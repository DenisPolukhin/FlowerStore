using AutoMapper;
using AutoMapper.QueryableExtensions;
using FlowStoreBackend.Common.Exceptions;
using FlowStoreBackend.Common.Helpers;
using FlowStoreBackend.Common.Pagination;
using FlowStoreBackend.Database.Models;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Models.Category;
using FlowStoreBackend.Logic.Models.Page;
using FlowStoreBackend.Logic.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace FlowStoreBackend.Logic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly DatabaseContext _databaseContext;
        private readonly IMapper _mapper;
        public ProductsService(DatabaseContext databaseContext, IMapper mapper)
        {
            _databaseContext = databaseContext;
            _mapper = mapper;
        }

        public async Task<IPaginatedList<ProductModel>> GetCategoryProductAsync(Guid categoryId, PageModel pageModel)
        {
            return await _databaseContext.Products
                .Where(x => x.CategoryId == categoryId)
                .ProjectTo<ProductModel>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(pageModel.Index, pageModel.Size);
        }

        public async Task<ProductModel> GetDetailsAsync(Guid id)
        {
            var product = await _databaseContext.Products.FindAsync(id);
            if (product is null)
            {
                throw new EntityFindException();
            }

            return _mapper.Map<ProductModel>(product);
        }

        public async Task<IPaginatedList<ProductModel>> SearchAsync(string searchText, PageModel pageModel)
        {
            var searchTextToLower = searchText.Trim().ToLower();
            return await _databaseContext.Products
                .Include(x => x.Category)
                .Where(x => x.Name.ToLower().Contains(searchTextToLower) ||
                    x.Category.Name.Contains(searchTextToLower))
                .ProjectTo<ProductModel>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(pageModel.Index, pageModel.Size);
        }

        public async Task<IEnumerable<CategoryModel>> GetCategoriesAsync()
        {
            return await _databaseContext.Categories
                .ProjectTo<CategoryModel>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        public async Task<ProductModel> CreateAsync(CreateProductModel createProductModel)
        {
            if (!await _databaseContext.Categories.AnyAsync(c => c.Id == createProductModel.CategoryId))
            {
                throw new EntityFindException();
            }

            var product = _mapper.Map<Product>(createProductModel);

            await _databaseContext.Products.AddAsync(product);
            await _databaseContext.SaveChangesAsync();

            return _mapper.Map<ProductModel>(product);
        }

        public async Task<ProductModel> UpdateAsync(Guid id, UpdateProductModel updateProductModel)
        {
            var product = await _databaseContext.Products.FindAsync(id);
            if (product is null)
            {
                throw new EntityFindException();
            }

            if(product.CategoryId != updateProductModel.CategoryId)
            {
                _ = await _databaseContext.Categories.FindAsync(updateProductModel.CategoryId)
                    ?? throw new EntityFindException();
            }

            if(product.Price != updateProductModel.Price)
            {
                var priceHistory = new PriceHistory
                {
                    OldPrice = product.Price,
                    ProductId = product.Id
                };

                await _databaseContext.PriceHistory.AddAsync(priceHistory);
            }

            _mapper.Map(updateProductModel, product);
            await _databaseContext.SaveChangesAsync();

            return _mapper.Map<ProductModel>(product);
        }

        public async Task DeleteAsync(Guid id)
        {
            var product = await _databaseContext.Products.FindAsync(id);
            if (product is null)
            {
                throw new EntityFindException();
            }
            
            _databaseContext.Products.Remove(product);
            await _databaseContext.SaveChangesAsync();
        }
    }
}
