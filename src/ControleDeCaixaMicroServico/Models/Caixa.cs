using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Loja_do_seu_emanoel.Models
{
    public class Caixa
    {
        [Key]
        public string caixa_id { get; set; }
        public Dimensoes dimensoes{ get; set; }
    }
}