using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Mercado_Tittio_Estoque.Services.Models
{
    public class ProductStoreServiceModel
    {
        public int id { get; set; }
        public int produto { get; set; }
        public DateTime entrada { get; set; }
        public DateTime validade { get; set; }
        public int prateleira { get; set; }
        public int quantidade { get; set; }
        public int funcionario { get; set; }
        public int conferenciaValidade { get; set; }
        public int conferenciaBalanco { get; set; }
    }
}
