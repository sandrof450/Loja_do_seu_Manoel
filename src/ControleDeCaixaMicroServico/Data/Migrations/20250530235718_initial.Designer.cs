﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Teste_Loja_do_seu_emanoel.Data;

#nullable disable

namespace Teste_Loja_do_seu_emanoel.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20250530235718_initial")]
    partial class initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Teste_Loja_do_seu_emanoel.Models.Caixa", b =>
                {
                    b.Property<string>("caixa_id")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("caixa_id");

                    b.ToTable("Caixa");
                });

            modelBuilder.Entity("Teste_Loja_do_seu_emanoel.Models.Pedido", b =>
                {
                    b.Property<int>("Pedido_id")
                        .HasColumnType("int");

                    b.HasKey("Pedido_id");

                    b.ToTable("Pedido");
                });

            modelBuilder.Entity("Teste_Loja_do_seu_emanoel.Models.Produto", b =>
                {
                    b.Property<string>("produto_id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int?>("Pedido_id")
                        .HasColumnType("int");

                    b.HasKey("produto_id");

                    b.HasIndex("Pedido_id");

                    b.ToTable("Produto");
                });

            modelBuilder.Entity("Teste_Loja_do_seu_emanoel.Models.Caixa", b =>
                {
                    b.OwnsOne("Teste_Loja_do_seu_emanoel.Models.Dimensoes", "dimensoes", b1 =>
                        {
                            b1.Property<string>("caixa_id")
                                .HasColumnType("nvarchar(450)");

                            b1.Property<int>("altura")
                                .HasColumnType("int");

                            b1.Property<int>("comprimento")
                                .HasColumnType("int");

                            b1.Property<int>("largura")
                                .HasColumnType("int");

                            b1.HasKey("caixa_id");

                            b1.ToTable("Caixa");

                            b1.WithOwner()
                                .HasForeignKey("caixa_id");
                        });

                    b.Navigation("dimensoes")
                        .IsRequired();
                });

            modelBuilder.Entity("Teste_Loja_do_seu_emanoel.Models.Produto", b =>
                {
                    b.HasOne("Teste_Loja_do_seu_emanoel.Models.Pedido", null)
                        .WithMany("produtos")
                        .HasForeignKey("Pedido_id");
                });

            modelBuilder.Entity("Teste_Loja_do_seu_emanoel.Models.Pedido", b =>
                {
                    b.Navigation("produtos");
                });
#pragma warning restore 612, 618
        }
    }
}
