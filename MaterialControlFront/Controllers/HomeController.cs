using MaterialControlFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MaterialControlFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IConfiguration _Configure;
        private readonly string _apiBaseUrl;
        public HomeController(ILogger<HomeController> logger, IConfiguration configuration)
        {
            _logger = logger;
            _Configure = configuration;
            _apiBaseUrl = _Configure.GetValue<string>("WebAPIBaseUrl");

        }

        public IActionResult Index()
        {
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
    }
}