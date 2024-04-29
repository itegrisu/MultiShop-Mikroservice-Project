using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductImagesDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Services.ProductImageServices;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductImageImageServices
{
    public class ProductImageServices : IProductImageServices
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductImages> _productImageColllection;

        public ProductImageServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productImageColllection = database.GetCollection<ProductImages>(_databaseSettings.ProductImageCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            var values = _mapper.Map<ProductImages>(createProductImageDto);
            await _productImageColllection.InsertOneAsync(values);
        }

        public async Task DeleteProductImageAsync(string id)
        {
            await _productImageColllection.DeleteOneAsync(x => x.ProductImagesId == id);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImageAsync()
        {
            var values = await _productImageColllection.Find<ProductImages>(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductImageDto>>(values);
        }

        public async Task<GetByIdProductImageDto> GetByIdProductImage(string id)
        {
            var values = await _productImageColllection.Find<ProductImages>(x => x.ProductImagesId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductImageDto>(values);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            var values = _mapper.Map<ProductImages>(updateProductImageDto);
            await _productImageColllection.FindOneAndReplaceAsync(x => x.ProductImagesId == updateProductImageDto.ProductImagesId, values);
        }
    }
}
