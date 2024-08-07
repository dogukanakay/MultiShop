using AutoMapper;
using MongoDB.Bson;
using MongoDB.Driver;
using MultiShop.Catalog.Entities;
using MultiShop.Catalog.Settings;

namespace MultiShop.Catalog.Services.StatisticServices
{
    public class StatisticService : IStatisticService
    {
        private readonly IMongoCollection<Category> _categoryCollection;
        private readonly IMongoCollection<Product> _productCollection;
        private readonly IMongoCollection<Brand> _brandCollection;

        public StatisticService(IDatabaseSettings _databaseSettings)
        {
            var client = new MongoClient(_databaseSettings.ConnectionString);
            var database = client.GetDatabase(_databaseSettings.DatabaseName);
            _productCollection = database.GetCollection<Product>(_databaseSettings.ProductCollectionName);
            _categoryCollection = database.GetCollection<Category>(_databaseSettings.CategoryCollectionName);
            _brandCollection = database.GetCollection<Brand>(_databaseSettings.BrandCollectionName);

        }

        public async Task<long> GetBrandCountAsync()
        {
            return await _brandCollection.CountDocumentsAsync(FilterDefinition<Brand>.Empty);
        }

        public async Task<long> GetCategoryCountAsync()
        {
            return await _categoryCollection.CountDocumentsAsync(FilterDefinition<Category>.Empty);
        }

        public async Task<string> GetMaxPriceProductNameAsync()
        {
            var filter = Builders<Product>.Filter.Exists(p => p.ProductPrice);
            var sort = Builders<Product>.Sort.Descending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductId");

            var product = await _productCollection.Find(filter)
                                                  .Sort(sort)
                                                  .Project(projection)
                                                  .FirstOrDefaultAsync();

            return product == null ? "No product found" : product.GetValue("ProductName").AsString;
        }

        public async Task<string> GetMinPriceProductNameAsync()
        {
            var filter = Builders<Product>.Filter.Exists(p => p.ProductPrice);
            var sort = Builders<Product>.Sort.Ascending(x => x.ProductPrice);
            var projection = Builders<Product>.Projection.Include(y => y.ProductName).Exclude("ProductId");

            var product = await _productCollection.Find(filter)
                                                  .Sort(sort)
                                                  .Project(projection)
                                                  .FirstOrDefaultAsync();

            return product == null ? "No product found" : product.GetValue("ProductName").AsString;
        }



        public async Task<decimal> GetProductAvgPriceAsync()
        {
            var result = await _productCollection.Aggregate()
         .Group(product => 1, g => new { AveragePrice = g.Average(p => (double)p.ProductPrice) })
         .FirstOrDefaultAsync();

            // Eğer result null ise veya AveragePrice değeri null ise 0 döndür
            if (result == null || result.AveragePrice == null)
            {
                return 0;
            }

            // Double türünden Decimal türüne dönüştür
            return Convert.ToDecimal(result.AveragePrice);
        }

        public async Task<long> GetProductCountAsync()
        {
            return await _productCollection.CountDocumentsAsync(FilterDefinition<Product>.Empty);
        }
    }
}
