using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Mercado_Tittio_Estoque.Services.Models
{
    public class ProductServiceModel
    {
        public int id { get; set; }
        public string descricao { get; set; }
        public string pronuncia { get; set; }
        public string img { get; set; }
        public string codigoLoja { get; set; }
        public double custoUnitario { get; set; }
        public double valorVenda { get; set; }
        public double valorPromocao { get; set; }
        public string gramatura { get; set; }
        public string embalagem { get; set; }
        public string peso { get; set; }
        public int igualaProduto { get; set; }
        public int itensCaixa { get; set; }
        public int volume { get; set; }
        public bool validade { get; set; }
        public string informacao { get; set; }
    }
}
