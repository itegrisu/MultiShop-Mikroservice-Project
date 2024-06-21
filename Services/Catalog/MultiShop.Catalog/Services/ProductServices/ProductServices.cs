using AutoMapper;
using MongoDB.Driver;
using MultiShop.Catalog.Dtos.ProductDtos;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.ProductServices
{
    public class ProductServices : IProductServices
    {
        private readonly IMapper _mapper;
        private readonly IMongoCollection<Product> _productColllection;
        private readonly IMongoCollection<Category> _categoryColllection;

        public ProductServices(IMapper mapper, IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productColllection = database.GetCollection<Product>(_databaseSettings.ProductiCollectionName);
            _categoryColllection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _mapper = mapper;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            var values = _mapper.Map<Product>(createProductDto);
            await _productColllection.InsertOneAsync(values);
        }

        public async Task DeleteProductAsync(string id)
        {
            await _productColllection.DeleteOneAsync(x => x.ProductId == id);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            var values = await _productColllection.Find<Product>(x => true).ToListAsync();
            return _mapper.Map<List<ResultProductDto>>(values);
        }

        public async Task<GetByIdProductDto> GetByIdProduct(string id)
        {
            var values = await _productColllection.Find<Product>(x => x.ProductId == id).FirstOrDefaultAsync();
            return _mapper.Map<GetByIdProductDto>(values);
        }

        public async Task<List<ResultProdıctsWithCategoryDto>> GetProductsWithCategoryAsync()
        {
            var values = await _productColllection.Find(x => true).ToListAsync();
            foreach (var item in values)
            {
                item.Category = await _categoryColllection.Find<Category>(x => x.CategoryId == item.CategoryId).FirstAsync();
            }
            return _mapper.Map<List<ResultProdıctsWithCategoryDto>>(values);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            var values = _mapper.Map<Product>(updateProductDto);
            await _productColllection.FindOneAndReplaceAsync(x => x.ProductId == updateProductDto.ProductId, values);
        }
    }
}
