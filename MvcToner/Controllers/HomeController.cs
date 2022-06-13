using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using MvcToner.Models;
using MvcToner.Data;

namespace Movies.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;


            
        }
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult AddPosition(int id = 1)
        //{
        //    return 
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}