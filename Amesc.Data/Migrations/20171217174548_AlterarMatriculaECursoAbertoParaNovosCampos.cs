using Microsoft.EntityFrameworkCore.Migrations;

namespace Amesc.Data.Migrations
{
    public partial class AlterarMatriculaECursoAbertoParaNovosCampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "ValorPago",
                table: "Matriculas",
                type: "decimal(18, 2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Codigo",
                table: "CursosAbertos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorPago",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "Codigo",
                table: "CursosAbertos");
        }
    }
}
