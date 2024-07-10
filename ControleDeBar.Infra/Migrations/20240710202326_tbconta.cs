using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ControleDeBar.Infra.Migrations
{
    /// <inheritdoc />
    public partial class tbconta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Conta_Id",
                table: "TBPedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TBConta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mesa_Id = table.Column<int>(type: "int", nullable: false),
                    Garcom_Id = table.Column<int>(type: "int", nullable: false),
                    ContaPaga = table.Column<bool>(type: "bit", nullable: false),
                    Abertura = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fechamento = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBConta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBConta_TBGarcom_Garcom_Id",
                        column: x => x.Garcom_Id,
                        principalTable: "TBGarcom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBConta_TBMesa_Mesa_Id",
                        column: x => x.Mesa_Id,
                        principalTable: "TBMesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBPedido_Conta_Id",
                table: "TBPedido",
                column: "Conta_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBConta_Garcom_Id",
                table: "TBConta",
                column: "Garcom_Id");

            migrationBuilder.CreateIndex(
                name: "IX_TBConta_Mesa_Id",
                table: "TBConta",
                column: "Mesa_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TBPedido_TBConta",
                table: "TBPedido",
                column: "Conta_Id",
                principalTable: "TBConta",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TBPedido_TBConta",
                table: "TBPedido");

            migrationBuilder.DropTable(
                name: "TBConta");

            migrationBuilder.DropIndex(
                name: "IX_TBPedido_Conta_Id",
                table: "TBPedido");

            migrationBuilder.DropColumn(
                name: "Conta_Id",
                table: "TBPedido");
        }
    }
}
