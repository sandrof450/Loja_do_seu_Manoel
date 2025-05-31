using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste_Loja_do_seu_emanoel.Data;
using Teste_Loja_do_seu_emanoel.Models;

namespace Teste_Loja_do_seu_emanoel.services
{
    public class CaixaService
    {
        public PedidoCaixa CaixaSelector(DataContext context ,Pedido pedido)
        {
            //Somar dimenssões do produto
            var totalAltura = pedido.produtos.Max(p => p.dimensoes.altura);
            var totalLargura = pedido.produtos.Max(p => p.dimensoes.largura);
            var totalComprimento = pedido.produtos.Max(p => p.dimensoes.comprimento);

            //Filtrar por caixaS que comportem a dimensão
            var caixasFiltradas = context.Caixa.Where(
                c => c.dimensoes.altura >= totalAltura
                && c.dimensoes.largura >= totalLargura
                && c.dimensoes.comprimento >= totalComprimento
            ).ToList();

            //Selecionar entre as caixas que comportem o volume a mais adequada
            var caixaSelecionada = 
            caixasFiltradas.OrderBy(
                c =>
                c.dimensoes.altura
                * c.dimensoes.largura
                * c.dimensoes.comprimento
            ).FirstOrDefault();

            if (caixaSelecionada == null)
            {
                return new PedidoCaixa();
            }

            var result = new PedidoCaixa
            {
                Pedido_id = pedido.Pedido_id,
                caixa_id = caixaSelecionada.caixa_id,
                Produtos = pedido.produtos.Select(p => p.produto_id).ToList()
            };

            return result;
        }
    }
}