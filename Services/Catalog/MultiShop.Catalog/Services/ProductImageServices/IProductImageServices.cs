using MultiShop.Catalog.Dtos.ProductImagesDtos;

namespace MultiShop.Catalog.Services.ProductImageServices
{
    public interface IProductImageServices
    {
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string id);
        Task<GetByIdProductImageDto> GetByIdProductImage(string id);
        Task<List<ResultProductImageDto>> GetAllProductImageAsync();
    }
}
