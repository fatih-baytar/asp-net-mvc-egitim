using Microsoft.AspNetCore.Mvc;
using MVCSessionYapisi.Models;
using System.Diagnostics;

namespace MVCSessionYapisi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            HttpContext.Session.SetString("UserName", model.UserName);
            return View();
        }

        public IActionResult Privacy()
        {
            var userName = HttpContext.Session.GetString("UserName");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}