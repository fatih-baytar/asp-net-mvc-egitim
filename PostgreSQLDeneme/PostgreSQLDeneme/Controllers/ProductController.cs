using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostgreSQLDeneme.Models;

namespace PostgreSQLDeneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _context.Products.Find(id);
        }
        [HttpPost]
        public Product Post([FromBody] Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product product)
        {
            var prod = _context.Products.Find(id);
            prod.Name = product.Name;
            prod.Description = product.Description;
            _context.SaveChanges();
        }
        [HttpDelete("{id}")]
        public int Delete(int id)
        {
            var product = _context.Products.Find(id);
            _context.Products.Remove(product);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
