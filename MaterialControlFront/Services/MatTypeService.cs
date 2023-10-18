using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MaterialControlFront.Interfaces;
using MaterialControlFront.Models;
using Newtonsoft.Json;

namespace MaterialControlFront.Services
{
    public class MatTypeService : IMatTypeService
    {
        private readonly HttpClient _client;
        private readonly string _apiBaseUrl;
        public MatTypeService(HttpClient client, IConfiguration configuration)
        {
            _client = client;
            _apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }
        public IEnumerable<MatTypeViewModel> GetAll()
        {
            // var response = await _client.GetAsync(_apiBaseUrl + "api/MatType/GetAll");
            // return await response.ReadContentAsync<List<MatTypeModelView>>();

            List<MatTypeViewModel> model = null;
            string url = _apiBaseUrl + "api/MatType/GetAll";
            var response = _client.GetAsync(url).Result;
            string jsonString = response.Content.ReadAsStringAsync().Result;
            model = JsonConvert.DeserializeObject<List<MatTypeViewModel>>(jsonString);
            return model;
        }

        public MatTypeViewModel GetByCode(string code)
        {
            MatTypeViewModel model = null;
            string url = _apiBaseUrl + "api/MatType/GetMatType?code="+ code +"";
            var response = _client.GetAsync(url).Result;
            string jsonString = response.Content.ReadAsStringAsync().Result ;
            model = JsonConvert.DeserializeObject<MatTypeViewModel>(jsonString);
            return model;
        }

        public bool Add(MatTypeModel model)
        {
            string url = _apiBaseUrl + "api/MatType/Add";
            JsonContent content = JsonContent.Create(model);
            // StringContent content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
            var response = _client.PostAsync(url, content).Result;
            string jsonString = response.Content.ReadAsStringAsync().Result ;
            ResultModel rsModel = JsonConvert.DeserializeObject<ResultModel>(jsonString);
            if(rsModel.Status == 201){
                return true;
            }
            else{
                return false;
            }
        }

        public bool Edit(MatTypeModel model)
        {
            string url = _apiBaseUrl + "api/MatType/Edit";
            JsonContent content = JsonContent.Create(model);
            var response = _client.PutAsync(url, content).Result;
            string jsonString = response.Content.ReadAsStringAsync().Result;
            ResultModel rsModel = JsonConvert.DeserializeObject<ResultModel>(jsonString);
            if(rsModel.Status == 202){
                return true;
            }
            else{
                return false;
            }
        }

        public bool Delete(string code)
        {
            MatTypeViewModel model = null;
            string url = _apiBaseUrl + "api/MatType/Delete?code="+ code +"";
            var response = _client.DeleteAsync(url).Result;
            string jsonString = response.Content.ReadAsStringAsync().Result;
            ResultModel rsModel = JsonConvert.DeserializeObject<ResultModel>(jsonString);
            if(rsModel.Status == 204){
                return true;
            }
            else{
                return false;
            }
        }
    }
}