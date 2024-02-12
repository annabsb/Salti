using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saltie_Backend.Migrations
{
    /// <inheritdoc />
    public partial class attpedido : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Vinhos_produtoid",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Vinhos_vinhoid",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_vinhoid",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "vinhoid",
                table: "Pedidos");

            migrationBuilder.AlterColumn<int>(
                name: "produtoid",
                table: "Itens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pedidoid",
                table: "Itens",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Itens_Pedidoid",
                table: "Itens",
                column: "Pedidoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Pedidos_Pedidoid",
                table: "Itens",
                column: "Pedidoid",
                principalTable: "Pedidos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Vinhos_produtoid",
                table: "Itens",
                column: "produtoid",
                principalTable: "Vinhos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Pedidos_Pedidoid",
                table: "Itens");

            migrationBuilder.DropForeignKey(
                name: "FK_Itens_Vinhos_produtoid",
                table: "Itens");

            migrationBuilder.DropIndex(
                name: "IX_Itens_Pedidoid",
                table: "Itens");

            migrationBuilder.DropColumn(
                name: "Pedidoid",
                table: "Itens");

            migrationBuilder.AddColumn<int>(
                name: "vinhoid",
                table: "Pedidos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "produtoid",
                table: "Itens",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_vinhoid",
                table: "Pedidos",
                column: "vinhoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Itens_Vinhos_produtoid",
                table: "Itens",
                column: "produtoid",
                principalTable: "Vinhos",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Vinhos_vinhoid",
                table: "Pedidos",
                column: "vinhoid",
                principalTable: "Vinhos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
