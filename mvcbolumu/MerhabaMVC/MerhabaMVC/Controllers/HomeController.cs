using MerhabaMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MerhabaMVC.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Merhaba()
        {
            return View();
        }
       
    }
}