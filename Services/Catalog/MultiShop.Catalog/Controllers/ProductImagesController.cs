using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImagesDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageServices _ProductImagesServices;
        public ProductImagesController(IProductImageServices ProductImagesServices)
        {
            _ProductImagesServices = ProductImagesServices;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImagesList()
        {
            var values = await _ProductImagesServices.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImagesById(string id)
        {
            var values = await _ProductImagesServices.GetByIdProductImage(id);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProductImages(CreateProductImageDto createProductImagesDto)
        {
            await _ProductImagesServices.CreateProductImageAsync(createProductImagesDto);
            return Ok("Ürün resmi başarıyla eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategoy(string id)
        {
            await _ProductImagesServices.DeleteProductImageAsync(id);
            return Ok("Ürün resmi başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCaregory(UpdateProductImageDto updateProductImagesDto)
        {
            await _ProductImagesServices.UpdateProductImageAsync(updateProductImagesDto);
            return Ok("Ürün resmi başarıyla güncellendi");
        }
    }
}
