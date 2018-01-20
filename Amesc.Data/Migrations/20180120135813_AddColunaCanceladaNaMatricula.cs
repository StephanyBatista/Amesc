using Microsoft.EntityFrameworkCore.Migrations;

namespace Amesc.Data.Migrations
{
    public partial class AddColunaCanceladaNaMatricula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Cancelada",
                table: "Matriculas",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cancelada",
                table: "Matriculas");
        }
    }
}
