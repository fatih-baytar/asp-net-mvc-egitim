using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MSSQLVeritabaniIslemleri.Models;
using VeritabaniIslemleri.Data;

namespace MSSQLVeritabaniIslemleri.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductDbContext _context;
        private readonly IWebHostEnvironment _environment;
        

        public ProductController(ProductDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }
        
        public async Task<IActionResult> ProductAdd()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductAdd([FromForm]ProductAddModel productAddModel)
        {

            var imagesFolder = Path.Combine(_environment.WebRootPath, "images");
            var productImageName = CreateImageName(productAddModel.Name)+"."+GetFileExtension(productAddModel.File.FileName);
            var filePath = Path.Combine(imagesFolder, productImageName);
            await productAddModel.File.CopyToAsync(new FileStream(filePath, FileMode.Create));

            var newProduct = new Product
            {
                Name = productAddModel.Name,
                Description = productAddModel.Description,
                Price = productAddModel.Price,
                ImageUrl = "images/" + productImageName
            };
            _context.Products.Add(newProduct);
            await _context.SaveChangesAsync();
            return View();
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if(id==null) return RedirectToAction("Index");

            var product = await _context.Products.FirstOrDefaultAsync(p=>p.Id==id);
            if (product == null) return RedirectToAction("Index");

            return View(product);
        }
        [HttpPost]
        public async Task<IActionResult> Detail([FromForm]ProductAddModel productAddModel,int id)
        {

            var product = _context.Products.FirstOrDefault(p=>p.Id==id);
            if (product == null) return RedirectToAction("Index");
            product.Name = productAddModel.Name;
            product.Description = productAddModel.Description;
            product.Price = productAddModel.Price;

            if (productAddModel.File != null)
            {
                var imagesFolder = Path.Combine(_environment.WebRootPath, "images");
                var productImageName = CreateImageName(productAddModel.Name) + "." + GetFileExtension(productAddModel.File.FileName);
                var filePath = Path.Combine(imagesFolder, productImageName);
                var fs = new FileStream(filePath, FileMode.Create);
                await productAddModel.File.CopyToAsync(fs);
                await fs.FlushAsync();
                await fs.DisposeAsync();
                product.ImageUrl = "images/"+productImageName; 
            }

            await _context.SaveChangesAsync();
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> ProductDelete([FromBody]ProductDeleteModel productDeleteModel)
        {
            if (productDeleteModel == null)
                return BadRequest();

            var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == productDeleteModel.ProductId);
            if (product == null) return BadRequest();

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("1"); //Başarılı
        }
        
        private string CreateImageName(string name)
        {
            return name.Replace(" ", "").ToLower();
        }
        private string GetFileExtension(string fileName)
        {
            return fileName.Split('.').Last();
        }
    }
}
