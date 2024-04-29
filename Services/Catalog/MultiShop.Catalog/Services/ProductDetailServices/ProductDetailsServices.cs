using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDetailsDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductDetailServices
{
    public class ProductDetailsServices : IProductDetailsServices
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<ProductDetail> _productDetailColllection;

        public ProductDetailsServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productDetailColllection = database.GetCollection<ProductDetail>(_databaseSettings.ProductDetailCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailsDto)
        {
            var values = _mapper.Map<ProductDetail>(createProductDetailsDto);
            await _productDetailColllection.InsertOneAsync(values);
        }

        public async Task DeleteProductDetailAsync(string id)
        {
            await _productDetailColllection.DeleteOneAsync(x => x.ProductDetailId == id);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailAsync()
        {
            var values = await _productDetailColllection.Find<ProductDetail>(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDetailDto>>(values);
        }

        public async Task<GetByIdProductDetailDto> GetByIdProductDetail(string id)
        {
            var values = await _productDetailColllection.Find<ProductDetail>(x => x.ProductDetailId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDetailDto>(values);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailsDto)
        {
            var values = _mapper.Map<ProductDetail>(updateProductDetailsDto);
            await _productDetailColllection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailsDto.ProductDetailId, values);
        }
    }
}
