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
        public decimal salario { get; set; }
        public decimal salarioBonus { get; set; }
        public decimal valeCompra { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string informacao { get; set; }
        public bool habilitado { get; set; }

    }
}
