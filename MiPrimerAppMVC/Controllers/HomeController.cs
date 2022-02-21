using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiPrimerAppMVC.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiPrimerAppMVC.Controllers
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
            ViewData["Mensaje"]="Mensaje usando view data";
            ViewBag.Message = "Mensaje a traves de viewbag dentro del controlador";
            ViewBag.Entero = 5;
            ViewBag.Decimal = 10.34m;
            ViewBag.Fecha = DateTime.Now;
            ViewData["Decimal2"]=5.83m;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult ViewDemo()
        {
            ViewBag.Title = "Vista Demo";
            ViewData["Title"] = "Prueba";
            ViewBag.Entero = 5;
            return View();
        }
    }
}
