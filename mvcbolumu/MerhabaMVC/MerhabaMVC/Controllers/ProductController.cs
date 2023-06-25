using MerhabaMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace MerhabaMVC.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var productList = new List<Product>();
            productList.Add(new Product { Id = 1, Name = "Ürün 1", Price = 3.5m });
            productList.Add(new Product { Id = 2, Name = "Ürün 2", Price = 3m });
            productList.Add(new Product { Id = 3, Name = "Ürün 3", Price = 6m });
            productList.Add(new Product { Id = 4, Name = "Ürün 4", Price = 7m });
            productList.Add(new Product { Id = 5, Name = "Ürün 5", Price = 2m });
            productList.Add(new Product { Id = 6, Name = "Ürün 6", Price = 1.2m });
            productList.Add(new Product { Id = 7, Name = "Ürün 7", Price = 2.4m });

            ViewBag.UrunSayisi = productList.Count;
            ViewData["IlkUrun"] = productList.First();
            return View(productList);
        }
        [HttpGet]
        public IActionResult AddProduct()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddProduct(Product product)
        {
            return View();
        }
    }
}
