using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Teste_Loja_do_seu_emanoel.Models
{
    public class PedidoCaixa
    {
        [NotMapped]
        public int Pedido_id { get; set; }
        [NotMapped]
        public string caixa_id { get; set; }
        [NotMapped]
        public List<string> Produtos { get; set; }
        [NotMapped]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Observacao { get; set; }
    }
}