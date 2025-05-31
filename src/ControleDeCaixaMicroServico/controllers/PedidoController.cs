using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Teste_Loja_do_seu_emanoel.Data;
using Teste_Loja_do_seu_emanoel.Models;
using Teste_Loja_do_seu_emanoel.services;
using Microsoft.Data.SqlClient;

namespace Teste_Loja_do_seu_emanoel.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PedidoController : ControllerBase
    {
        private readonly DataContext _context;

        public PedidoController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult CriarPedido([FromBody] List<Pedido> pedidos)
        {
            if (pedidos == null || !pedidos.Any())
            {
                return BadRequest("Nenhum pedido foi enviado");
            }

            var resultadosCaixas = new List<PedidoCaixa>();

            foreach (var pedido in pedidos)
            {
                _context.Pedido.Add(pedido);

                CaixaService caixaService = new CaixaService();
                var caixasFiltradas = caixaService.CaixaSelector(_context, pedido);
                
                resultadosCaixas.Add(new PedidoCaixa
                {
                    Pedido_id = pedido.Pedido_id,
                    caixa_id = caixasFiltradas.caixa_id,
                    Produtos = pedido.produtos.Select(p => p.produto_id).ToList(),
                    Observacao =  caixasFiltradas.caixa_id == null ?  "Produto não cabe em nenhuma caixa disponível.": null
                });
            }          
            if (_context.SaveChanges() > 0)
            {
                return Ok(resultadosCaixas);
            }
        
        return BadRequest("Nenhum pedido foi salvo no banco de dados");
        }

        [HttpPost("criarCaixa")]
        public IActionResult criarCaixa([FromBody] Caixa caixa)
        {
            _context.Caixa.Add(caixa);
            if (_context.SaveChanges() > 0)
            {
                return Ok(caixa);
            }
            return BadRequest("Ocorreu um erro!");
        }

    }
}