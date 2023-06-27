using MerhabaWebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MerhabaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly List<Product> _products;
        public ProductController()
        {
            _products = new List<Product>();
            _products.Add(new Product { Id = 1, Name = "Product 1", Description = "Product1 Description" });
            _products.Add(new Product { Id = 2, Name = "Product 2", Description = "Product2 Description" });
            _products.Add(new Product { Id = 3, Name = "Product 3", Description = "Product3 Description" });
            _products.Add(new Product { Id = 4, Name = "Product 4", Description = "Product4 Description" });
        }
        [HttpGet]
        public List<Product> Get()
        {
            
            return _products;
        }
        [HttpGet("{id}")]
        public Product Get(int? id)
        {
            var product = _products.FirstOrDefault(x => x.Id == id);
            return product;
        }
        [HttpPost]
        public Product Post(Product product)
        {
            _products.Add(product);
            return product;
        }
        [HttpPut("{id}")]
        public Product Put(int? id, Product product)
        {
            var prod = _products.FirstOrDefault(product => product.Id == id);
            prod.Name= product.Name;
            prod.Description= product.Description;


            return prod;
        }
        [HttpDelete("{id}")]
        public Product Delete(int? id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            _products.Remove(product);
            return product;
        }
    }
}
