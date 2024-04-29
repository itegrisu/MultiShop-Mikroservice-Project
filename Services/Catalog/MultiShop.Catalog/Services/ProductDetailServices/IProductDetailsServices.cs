using MultiShop.Catalog.Dtos.ProductDetailsDtos;
namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailsServices
    {
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailsDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailsDto);
        Task DeleteProductDetailAsync(string id);
        Task<GetByIdProductDetailDto> GetByIdProductDetail(string id);
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
    }
}
