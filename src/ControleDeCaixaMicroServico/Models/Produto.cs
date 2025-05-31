using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Teste_Loja_do_seu_emanoel.Models
{
    public class Produto
    {
        [Key]
        public string produto_id { get; set; }
        [NotMapped]
        public Dimensoes dimensoes { get; set; }
    }
}