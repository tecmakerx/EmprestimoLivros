using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmprestimoLivros.Migrations
{
    public partial class CriacaoDoBD : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Forneceor",
                table: "Emprestimos",
                newName: "LivroEmprestado");

            migrationBuilder.RenameColumn(
                name: "DataUltimoEmprestiimo",
                table: "Emprestimos",
                newName: "DataUltimoEmprestimo");

            migrationBuilder.AddColumn<string>(
                name: "Fornecedor",
                table: "Emprestimos",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Fornecedor",
                table: "Emprestimos");

            migrationBuilder.RenameColumn(
                name: "LivroEmprestado",
                table: "Emprestimos",
                newName: "Forneceor");

            migrationBuilder.RenameColumn(
                name: "DataUltimoEmprestimo",
                table: "Emprestimos",
                newName: "DataUltimoEmprestiimo");
        }
    }
}
