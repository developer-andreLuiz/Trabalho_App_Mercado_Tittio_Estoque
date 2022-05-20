using System;
using System.Collections.Generic;
using System.Text;

namespace Trabalho_App_Mercado_Tittio_Estoque.Services.Models
{
    public class EmployeeServiceModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string senha { get; set; }
        public int nivel { get; set; }
        public int cargo { get; set; }
        public double salario { get; set; }
        public double salarioBonus { get; set; }
        public double valeCompra { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string informacao { get; set; }
        public int habilitado { get; set; }
     
    }
}
