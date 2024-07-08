using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeBar.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddPedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBPedido",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Produto_Id = table.Column<int>(type: "int", nullable: false),
                    NumeroPedido = table.Column<int>(type: "int", nullable: false),
                    NumeroMesa = table.Column<int>(type: "int", nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(18,0)", nullable: false),
                    Qtde = table.Column<int>(type: "int", nullable: false),
                    ExcluiItem = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBPedido", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBPedido_TBProdutos",
                        column: x => x.Produto_Id,
                        principalTable: "TBProdutos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPedido_Produto_Id",
                table: "TBPedido",
                column: "Produto_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBPedido");
        }
    }
}
