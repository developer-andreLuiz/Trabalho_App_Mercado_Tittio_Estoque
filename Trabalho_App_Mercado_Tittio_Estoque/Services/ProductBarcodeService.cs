using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Trabalho_App_Mercado_Tittio_Estoque.Services.Models;
namespace Trabalho_App_Mercado_Tittio_Estoque.Services
{
    public class ProductBarcodeService
    {
        public static ProductBarcodeService instance = new ProductBarcodeService();
        const string URL = "https://api-mercado-online.azurewebsites.net/api/produtocodigobarra";
        private HttpClient GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            client.DefaultRequestHeaders.Add("Connection", "close");
            return client;
        }
        public async Task<List<ProductBarcodeServiceModel>> GetAll()
        {
            string data = URL;
            HttpClient client = GetClient();
            var response = await client.GetAsync(data);
            if (response.IsSuccessStatusCode)//codigo 200
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<ProductBarcodeServiceModel>>(content);
            }
            return new List<ProductBarcodeServiceModel>();
        }
    }
}
