using la_mia_pizzeria_razor_layout.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace la_mia_pizzeria_razor_layout.Controllers
{
    public class GuestController : Controller
    {
        private readonly ILogger<GuestController> _logger;

        public GuestController(ILogger<GuestController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Contact()
        {
            
            return View();
        }




    }
}