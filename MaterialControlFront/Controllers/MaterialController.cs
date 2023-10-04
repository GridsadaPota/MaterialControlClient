using MaterialControlFront.Interfaces;
using MaterialControlFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using MaterialControlFront.Helpers;

namespace MaterialControlFront.Controllers
{
    public class MaterialController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _apiBaseUrl;
        private readonly ILogger<MaterialController> _logger;
        private IMatTypeService _mattypeService;

        public MaterialController(ILogger<MaterialController> logger, IMatTypeService matTypeService, HttpClient client, IConfiguration configuration)
        {
            _logger = logger;
            _mattypeService = matTypeService?? throw new ArgumentNullException(nameof(matTypeService));
            _client = client?? throw new ArgumentNullException(nameof(client));
            _apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }

        // public MaterialController(ILogger<MaterialController> logger, IMatTypeService matTypeService)
        // {
        //     _logger = logger;
        //     _mattypeService = matTypeService?? throw new ArgumentNullException(nameof(matTypeService));
        // }

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
            // // IEnumerable<MatTypeModelView> list = 
            // var mattypes = await _mattypeService.GetMatTypeAll();
            // return Json(mattypes);
            
            string url = _apiBaseUrl + "api/MatType/GetAll";
            var response = await _client.GetAsync(url);
            var contents = await response.ReadContentAsync<List<MatTypeModelView>>();
            return Json(contents);

        }
        public async Task<JsonResult> GetByCode(string code)
        {
            var mattypes = await _mattypeService.GetMatTypeByCode(code);
            return Json(mattypes);
        }


        [HttpPost]
        public async Task<JsonResult> Add([FromBody]MatTypeModel matType)
        {
            string url = _apiBaseUrl + "api/MatType/Add";
            #region Mock data
            // MatTypeModel dd = new MatTypeModel()
            // {
            //     type_id = 0,
            //     type_code = matType.type_name,
            //     type_name = matType.type_name,
            //     type_remark = "9999"
            // };
            #endregion
            
            StringContent content = new StringContent(JsonConvert.SerializeObject(matType),Encoding.UTF8, "application/json");
 
            var response = await _client.PostAsync(url, content);
            var contents = await response.Content.ReadAsStringAsync();
            return Json(contents);
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}