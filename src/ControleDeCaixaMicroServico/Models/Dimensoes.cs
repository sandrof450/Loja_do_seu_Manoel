using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Teste_Loja_do_seu_emanoel.Models
{
    public class Dimensoes
    {    
        public int altura { get; set; }
        public int largura { get; set; }
        public int comprimento { get; set; }
    }
}