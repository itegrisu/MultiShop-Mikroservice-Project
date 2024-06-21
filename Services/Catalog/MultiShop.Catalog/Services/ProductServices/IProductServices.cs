using MultiShop.Catalog.Dtos.ProductDtos;

namespace MultiShop.Catalog.Services.ProductServices
{
    public interface IProductServices
    {
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task DeleteProductAsync(string id);
        Task<GetByIdProductDto> GetByIdProduct(string id);
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProdıctsWithCategoryDto>> GetProductsWithCategoryAsync();

    }
}
