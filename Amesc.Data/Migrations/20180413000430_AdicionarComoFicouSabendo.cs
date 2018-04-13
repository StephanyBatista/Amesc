using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amesc.Data.Migrations
{
    public partial class AdicionarComoFicouSabendo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComoFicouSabendoId",
                table: "Matriculas",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ComoFicouSabendo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComoFicouSabendo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_ComoFicouSabendoId",
                table: "Matriculas",
                column: "ComoFicouSabendoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_ComoFicouSabendo_ComoFicouSabendoId",
                table: "Matriculas",
                column: "ComoFicouSabendoId",
                principalTable: "ComoFicouSabendo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"
                INSERT INTO ComoFicouSabendo VALUES ('Facebook');
                INSERT INTO ComoFicouSabendo VALUES ('E-mail');
                INSERT INTO ComoFicouSabendo VALUES ('Whatsapp');
                INSERT INTO ComoFicouSabendo VALUES ('Telefone');
                INSERT INTO ComoFicouSabendo VALUES ('Jornal');
                INSERT INTO ComoFicouSabendo VALUES ('Colega');
                INSERT INTO ComoFicouSabendo VALUES ('Outros');
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_ComoFicouSabendo_ComoFicouSabendoId",
                table: "Matriculas");

            migrationBuilder.DropTable(
                name: "ComoFicouSabendo");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_ComoFicouSabendoId",
                table: "Matriculas");

            migrationBuilder.DropColumn(
                name: "ComoFicouSabendoId",
                table: "Matriculas");
        }
    }
}
