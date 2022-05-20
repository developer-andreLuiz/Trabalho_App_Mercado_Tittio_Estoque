using System;
using System.Collections.Generic;
using System.Text;
using Trabalho_App_Mercado_Tittio_Estoque.Services.Models;

namespace Trabalho_App_Mercado_Tittio_Estoque.Helpers
{
    public class GlobalHelper
    {
        public static GlobalHelper instance = new GlobalHelper();
        
        
        public List<EmployeeServiceModel> listEmployee = new List<EmployeeServiceModel>();
        public List<EmployeeOccupationServiceModel> listEmployeeOccupation = new List<EmployeeOccupationServiceModel>();
        public List<ProductServiceModel> listProduct = new List<ProductServiceModel>();
        public List<ProductBarcodeServiceModel> listProductBarcode = new List<ProductBarcodeServiceModel>();
        public List<StoreShelfServiceModel> listStoreShelf = new List<StoreShelfServiceModel>();
        public List<ProductStoreServiceModel> listProductStore = new List<ProductStoreServiceModel>();



        public EmployeeServiceModel employee = null;
    }
}
