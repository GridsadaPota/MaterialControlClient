using MaterialControlFront.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;
using MaterialControlFront.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MaterialControlFront.Controllers
{
    public class MaterialController : Controller
    {
        // private readonly HttpClient _client;
        // private readonly string _apiBaseUrl;
        private readonly IMatTypeService _mattypeService;
        private readonly ILogger<MaterialController> _logger;

        // public MaterialController(ILogger<MaterialController> logger,  HttpClient client, IConfiguration configuration)
        // {
        //     _logger = logger;
        //     _client = client?? throw new ArgumentNullException(nameof(client));
        //     _apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        // }

        public MaterialController(ILogger<MaterialController> logger, IMatTypeService matTypeService)
        {
            _logger = logger;
            _mattypeService = matTypeService;
        }
        public IActionResult Index()
        {
            try
            {
                // List<MatTypeViewModel> model = null;
                // string url = _apiBaseUrl + "api/MatType/GetAll";
                // var task = _client.GetAsync(url)
                // .ContinueWith((taskwithresponse) =>
                // {
                //     var response = taskwithresponse.Result;
                //     var jsonString = response.Content.ReadAsStringAsync();
                //     jsonString.Wait();
                //     model = JsonConvert.DeserializeObject<List<MatTypeViewModel>>(jsonString.Result);

                // });
                // task.Wait();

                IEnumerable<MatTypeViewModel> model = _mattypeService.GetAll();
                return View(model);

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(MatTypeModel matType)
        {
            if(ModelState.IsValid)
            {
                // //get API
                // string url = _apiBaseUrl + "api/MatType/Add";
                // StringContent content = new StringContent(JsonConvert.SerializeObject(matType),Encoding.UTF8, "application/json");
                // var response = _client.PostAsync(url, content);
                // var contents = await response.Content.ReadAsStringAsync();

                //check before save
                MatTypeViewModel model = _mattypeService.GetByCode(matType.Type_Code);
                if(model.Type_Code == matType.Type_Code)
                {
                    ViewBag.isErrorMessage = true;
                    ViewBag.errorMessage = string.Format("รหัสนี้ {0} มีแล้วในระบบ", matType.Type_Code);
                    return View(matType);
                }

                //Save
                var result = _mattypeService.Add(matType);
                if(result == false){
                    ViewBag.isErrorMessage = true;
                    ViewBag.errorMessage = "Error ไม่สามารถ Add ได้";
                    return View(matType);
                }

                return RedirectToAction("Index");
            }
            return View(matType);
        }

        public IActionResult Edit(string code)
        {
            MatTypeViewModel matViewType = _mattypeService.GetByCode(code);
            MatTypeModel matType = new MatTypeModel()
            {
                Type_Id = matViewType.Type_Id,
                Type_Code = matViewType.Type_Code,
                Type_Name = matViewType.Type_Name,
                Type_Remark = matViewType.Type_Remark
            };
            return View(matType);
        }

        [HttpPost]
        public IActionResult Edit(MatTypeModel matType)
        {
            //Edit
            var result = _mattypeService.Edit(matType);
            if(result == false){
                ViewBag.isErrorMessage = true;
                ViewBag.errorMessage = "Error ไม่สามารถ Add ได้";
                return View(matType);
            }

            return RedirectToAction("Index");
        }


        public IActionResult Delete(string code)
        {
            //Delete
            var result = _mattypeService.Delete(code);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}