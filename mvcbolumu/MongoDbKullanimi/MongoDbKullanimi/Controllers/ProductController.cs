using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using MongoDbKullanimi.Models;

namespace MongoDbKullanimi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private MongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly IMongoCollection<Product> _collection;

        public ProductController()
        {
            _client = new MongoClient("mongodb://localhost:27017");
            _database = _client.GetDatabase("ProductDB");
            _collection = _database.GetCollection<Product>("Product");
        }

        [HttpGet]
        public List<Product> Get()
        {
            var productList = _collection.Find(p => true).ToList();
            return productList;

        }
        [HttpGet("{id}")]
        public Product Get(string id)
        {

            var product = _collection.Find(p => p.Id == id).FirstOrDefault();
            return product;
        }
        [HttpPost]
        public Product Post(Product product)
        {

            _collection.InsertOne(product);
            return product;
        }
        [HttpPut("{id}")]
        public Product Put(string id, Product product)
        {
            var filter = Builders<Product>.Filter.Eq(x => x.Id, id);
            var update = Builders<Product>.Update
                .Set(p => p.Name, product.Name)
                .Set(p => p.Description, product.Description);

            _collection.UpdateOne(filter, update);
            return product;
        }
        [HttpDelete("{id}")]
        public string Delete(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p=>p.Id, id);
            var deleteResult = _collection.DeleteOne(filter);
            return deleteResult.DeletedCount.ToString();
        }
        //CRUD = Create, Read, Update, Delete
    }
}
