using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailsServices _ProductDetailsServices;
        public ProductDetailsController(IProductDetailsServices ProductDetailsServices)
        {
            _ProductDetailsServices = ProductDetailsServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _ProductDetailsServices.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailsById(string id)
        {
            var values = await _ProductDetailsServices.GetByIdProductDetail(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductDetails(CreateProductDetailDto createProductDetailsDto)
        {
            await _ProductDetailsServices.CreateProductDetailAsync(createProductDetailsDto);
            return Ok("Ürün ayrıntısı başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoy(string id)
        {
            await _ProductDetailsServices.DeleteProductDetailAsync(id);
            return Ok("Ürün ayrıntısı başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCaregory(UpdateProductDetailDto updateProductDetailsDto)
        {
            await _ProductDetailsServices.UpdateProductDetailAsync(updateProductDetailsDto);
            return Ok("Ürün ayrıntısı başarıyla güncellendi");
        }
    }
}
