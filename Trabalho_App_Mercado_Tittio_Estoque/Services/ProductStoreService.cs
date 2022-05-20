using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio_Estoque.Services.Models;

namespace Trabalho_App_Mercado_Tittio_Estoque.Services
{
    public class ProductStoreService
    {
        public static ProductStoreService instance = new ProductStoreService();
        const string URL = "https://api-mercado-online.azurewebsites.net/api/produtoloja";
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<List<ProductStoreServiceModel>> GetAll()
        {
            string data = URL;
            HttpClient client = GetClient();
            var response = await client.GetAsync(data);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductStoreServiceModel>>(content);
            }
            return new List<ProductStoreServiceModel>();
        }
        public async Task<ProductStoreServiceModel> Create(ProductStoreServiceModel obj)
        {
            string data = URL;
            string json = JsonConvert.SerializeObject(obj);
            HttpClient client = GetClient();
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(data, content);
            if (response.IsSuccessStatusCode)
            {
                string contentReturn = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ProductStoreServiceModel>(contentReturn);
            }
            return new ProductStoreServiceModel();
        }
    }
}
