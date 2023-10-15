using MaterialControlFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;

namespace MaterialControlFront.Controllers
{
    public class MaterialController : Controller
    {
        private readonly HttpClient _client;
        private readonly string _apiBaseUrl;
        private readonly ILogger<MaterialController> _logger;

        public MaterialController(ILogger<MaterialController> logger,  HttpClient client, IConfiguration configuration)
        {
            _logger = logger;
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
            // List<MatTypeModel> matTypeList = new List<MatTypeModel>();
            // MatTypeModel matTypeModel = new MatTypeModel(){
            //     type_id = 1001,
            //     type_code= "MT0001",
            //     type_name = "DDDDDD"
            // };
            // matTypeList.Add(matTypeModel);

            List<MatTypeModel> model = null;
            string url = _apiBaseUrl + "api/MatType/GetAll";
            var task = _client.GetAsync(url)
            .ContinueWith((taskwithresponse) =>
            {
                var response = taskwithresponse.Result;
                var jsonString = response.Content.ReadAsStringAsync();
                jsonString.Wait();
                model = JsonConvert.DeserializeObject<List<MatTypeModel>>(jsonString.Result);

            });
            task.Wait();

            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }


        public IActionResult Edit()
        {
            return View();
        }

        public async Task<JsonResult> GetAll()
        {
            string url = _apiBaseUrl + "api/MatType/GetAll";
            var response = await _client.GetAsync(url);
            var contents = await response.Content.ReadFromJsonAsync<List<MatTypeModel>>();
            return Json(contents);

        }
        public async Task<JsonResult> GetByCode(string code)
        {
            string url = _apiBaseUrl + "api/MatType/GetMatType?code="+ code +"";
            var response = await _client.GetAsync(url);
            var contents = await response.Content.ReadFromJsonAsync<MatTypeModel>(); //await response.ReadContentAsync<List<MatTypeModelView>>();
            return Json(contents);
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