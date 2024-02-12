using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Saltie_Backend.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoNova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vinhos_Tipos_tipoId",
                table: "Vinhos");

            migrationBuilder.RenameColumn(
                name: "tipoId",
                table: "Vinhos",
                newName: "tipoid");

            migrationBuilder.RenameIndex(
                name: "IX_Vinhos_tipoId",
                table: "Vinhos",
                newName: "IX_Vinhos_tipoid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Tipos",
                newName: "id");

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    produtoid = table.Column<int>(type: "INTEGER", nullable: true),
                    qtd = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.id);
                    table.ForeignKey(
                        name: "FK_Itens_Vinhos_produtoid",
                        column: x => x.produtoid,
                        principalTable: "Vinhos",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Itens_produtoid",
                table: "Itens",
                column: "produtoid");

            migrationBuilder.AddForeignKey(
                name: "FK_Vinhos_Tipos_tipoid",
                table: "Vinhos",
                column: "tipoid",
                principalTable: "Tipos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vinhos_Tipos_tipoid",
                table: "Vinhos");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.RenameColumn(
                name: "tipoid",
                table: "Vinhos",
                newName: "tipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Vinhos_tipoid",
                table: "Vinhos",
                newName: "IX_Vinhos_tipoId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Tipos",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vinhos_Tipos_tipoId",
                table: "Vinhos",
                column: "tipoId",
                principalTable: "Tipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
