using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teste_Loja_do_seu_emanoel.Data.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Caixa",
                columns: table => new
                {
                    caixa_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    dimensoes_altura = table.Column<int>(type: "int", nullable: false),
                    dimensoes_largura = table.Column<int>(type: "int", nullable: false),
                    dimensoes_comprimento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caixa", x => x.caixa_id);
                });

            migrationBuilder.CreateTable(
                name: "Pedido",
                columns: table => new
                {
                    Pedido_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.Pedido_id);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    produto_id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Pedido_id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.produto_id);
                    table.ForeignKey(
                        name: "FK_Produto_Pedido_Pedido_id",
                        column: x => x.Pedido_id,
                        principalTable: "Pedido",
                        principalColumn: "Pedido_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_Pedido_id",
                table: "Produto",
                column: "Pedido_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Caixa");

            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Pedido");
        }
    }
}
