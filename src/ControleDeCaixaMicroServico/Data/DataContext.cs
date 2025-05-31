using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Teste_Loja_do_seu_emanoel.Models;

namespace Teste_Loja_do_seu_emanoel.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Caixa> Caixa { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Caixa>()
                .OwnsOne(c => c.dimensoes);
        }
    }
}