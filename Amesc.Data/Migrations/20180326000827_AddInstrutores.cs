using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amesc.Data.Migrations
{
    public partial class AddInstrutores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InstrutorDaTurma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Cargo = table.Column<int>(type: "int", nullable: false),
                    CursoAbertoId = table.Column<int>(type: "int", nullable: true),
                    InstrutorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InstrutorDaTurma", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InstrutorDaTurma_CursosAbertos_CursoAbertoId",
                        column: x => x.CursoAbertoId,
                        principalTable: "CursosAbertos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InstrutorDaTurma_Instrutores_InstrutorId",
                        column: x => x.InstrutorId,
                        principalTable: "Instrutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InstrutorDaTurma_CursoAbertoId",
                table: "InstrutorDaTurma",
                column: "CursoAbertoId");

            migrationBuilder.CreateIndex(
                name: "IX_InstrutorDaTurma_InstrutorId",
                table: "InstrutorDaTurma",
                column: "InstrutorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InstrutorDaTurma");
        }
    }
}
