using Microsoft.AspNetCore.Mvc;
using MSSQLVeritabaniIslemleri.Models;
using System.Diagnostics;

namespace MSSQLVeritabaniIslemleri.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        
    }
}