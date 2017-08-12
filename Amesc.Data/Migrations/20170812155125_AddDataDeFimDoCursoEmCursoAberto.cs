using System;
using Amesc.Data.Contexts;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Amesc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170812155125_AddDataDeFimDoCursoEmCursoAberto")]
    public partial class AddDataDeFimDoCursoEmCursoAberto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "FimDoCurso",
                table: "CursoAberto",
                nullable: true);

            migrationBuilder.RenameColumn(
                
                name: "DataDoCurso",
                newName: "InicioDoCurso",
                table: "CursoAberto");

            migrationBuilder.RenameColumn(

                name: "DataDeAbertura",
                newName: "PeriodoInicialParaMatricula",
                table: "CursoAberto");

            migrationBuilder.AlterColumn<DateTime?>(

                name: "PeriodoInicialParaMatricula",
                table: "CursoAberto",
                nullable: true);

            migrationBuilder.RenameColumn(

                name: "DataDeFechamento",
                newName: "PeriodoFinalParaMatricula",
                table: "CursoAberto");

            migrationBuilder.AlterColumn<DateTime?>(

                name: "PeriodoFinalParaMatricula",
                table: "CursoAberto",
                nullable: true);

            migrationBuilder.Sql("update cursoaberto set fimdocurso = dateadd(month, 1, iniciodocurso)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FimDoCurso",
                table: "CursoAberto");

            migrationBuilder.RenameColumn(

                name: "InicioDoCurso",
                newName: "DataDoCurso",
                table: "CursoAberto");

            migrationBuilder.RenameColumn(

                name: "PeriodoInicialParaMatricula",
                newName: "DataDeAbertura",
                table: "CursoAberto");

            migrationBuilder.RenameColumn(

                name: "PeriodoFinalParaMatricula",
                newName: "DataDeFechamento",
                table: "CursoAberto");
        }
    }
}
