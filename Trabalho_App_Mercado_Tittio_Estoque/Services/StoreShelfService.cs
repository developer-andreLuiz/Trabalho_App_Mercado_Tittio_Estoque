using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio_Estoque.Services.Models;
namespace Trabalho_App_Mercado_Tittio_Estoque.Services
{
    public class StoreShelfService
    {
        public static ProductService instance = new ProductService();
        const string URL = "https://api-mercado-online.azurewebsites.net/api/lojaprateleira";
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<List<StoreShelfServiceModel>> GetAll()
        {
            string data = URL;
            HttpClient client = GetClient();
            var response = await client.GetAsync(data);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<StoreShelfServiceModel>>(content);
            }
            return new List<StoreShelfServiceModel>();
        }
        public async Task<StoreShelfServiceModel> Update(StoreShelfServiceModel obj)
        {
            string data = URL + "/" + obj.id;
            string json = JsonConvert.SerializeObject(obj);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PutAsync(data, content);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string contentResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<StoreShelfServiceModel>(contentResponse);
            }
            return new StoreShelfServiceModel();
        }
    }
}
