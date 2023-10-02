using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaterialControlFront.Interfaces;
using MaterialControlFront.Models;
using MaterialControlFront.Helpers;

namespace MaterialControlFront.Services
{
    public class MatTypeService : IMatTypeService
    {
        private readonly HttpClient _client;
        private readonly string _apiBaseUrl;
        public MatTypeService(HttpClient client, IConfiguration configuration)
        {
            _client = client?? throw new ArgumentNullException(nameof(client));
            _apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IEnumerable<MatTypeModelView>> GetMatTypeAll()
        {
            var response = await _client.GetAsync(_apiBaseUrl + "api/MatType/GetAll");
            return await response.ReadContentAsync<List<MatTypeModelView>>();
        }

        public async Task<MatTypeModelView> GetMatTypeByCode(string code)
        {
            var response = await _client.GetAsync(_apiBaseUrl + "api/MatType/GetMatType?code="+ code +"");
            return await response.ReadContentAsync<MatTypeModelView>();
        }
    }
}