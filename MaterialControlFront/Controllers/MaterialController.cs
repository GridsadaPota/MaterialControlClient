using MaterialControlFront.Interfaces;
using MaterialControlFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MaterialControlFront.Controllers
{
    public class MaterialController : Controller
    {
        // private readonly HttpClient _client;
        // private readonly string _apiBaseUrl;
        private readonly ILogger<MaterialController> _logger;
        private IMatTypeService _mattypeService;

        // public MaterialController(ILogger<MaterialController> logger, HttpClient client, IConfiguration configuration)
        // {
        //     _logger = logger;
        //     _client = client?? throw new ArgumentNullException(nameof(client));
        //     _apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        // }
        public MaterialController(ILogger<MaterialController> logger, IMatTypeService matTypeService)
        {
            _logger = logger;
            _mattypeService = matTypeService?? throw new ArgumentNullException(nameof(matTypeService));
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<JsonResult> GetAll()
        {
            // IEnumerable<MatTypeModelView> list = 
            var mattypes = await _mattypeService.GetMatTypeAll();
            return Json(mattypes);

        }
        public async Task<JsonResult> GetByCode(string code)
        {
            var mattypes = await _mattypeService.GetMatTypeByCode(code);
            return Json(mattypes);
        }

        // public async Task<JsonResult> Add(MatTypeModelView matType)
        // {
        //     var mattypes = await ""; // await _mattypeService.GetMatTypeByCode(code);
        //     return Json(mattypes);
        // } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}