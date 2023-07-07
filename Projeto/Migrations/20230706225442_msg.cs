using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Projeto.Migrations
{
    /// <inheritdoc />
    public partial class msg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "score",
                table: "AspNetUsers",
                newName: "Score");

            migrationBuilder.RenameColumn(
                name: "click",
                table: "AspNetUsers",
                newName: "Click");

            migrationBuilder.AlterColumn<string>(
                name: "Frase",
                table: "Mensagem",
                type: "nvarchar(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Não é um botão");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Gorro de natal");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Score",
                table: "AspNetUsers",
                newName: "score");

            migrationBuilder.RenameColumn(
                name: "Click",
                table: "AspNetUsers",
                newName: "click");

            migrationBuilder.AlterColumn<string>(
                name: "Frase",
                table: "Mensagem",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(60)",
                oldMaxLength: 60);

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "not a button");

            migrationBuilder.UpdateData(
                table: "Itens",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Christmas Hat");
        }
    }
}
