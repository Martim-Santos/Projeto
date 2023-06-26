using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class controllers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Imagem" },
                values: new object[] { "Mais 1 click por click :)", "C:\\Users\\marti\\Desktop\\DW\\Projeto\\Projeto\\Projeto\\wwwroot\\imagens\\Item +1.png" });

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Boa");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "MULTIPLOS CLICKS");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "tantos clicks");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Definitivamente não é um botão");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Imagem" },
                values: new object[] { "Mais 1 click  por click :)", "Item +1.png" });

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 2,
                column: "Description",
                value: "Nice");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 3,
                column: "Description",
                value: "MULTICLICK");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 4,
                column: "Description",
                value: "So many clicks");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 5,
                column: "Description",
                value: "Definitly not a Button");
        }
    }
}
