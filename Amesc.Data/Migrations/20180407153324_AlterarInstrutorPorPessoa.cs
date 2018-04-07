using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amesc.Data.Migrations
{
    public partial class AlterarInstrutorPorPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrutorDaTurma_Instrutores_InstrutorId",
                table: "InstrutorDaTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrutorDaTurma_Pessoas_InstrutorId",
                table: "InstrutorDaTurma",
                column: "InstrutorId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql("DELETE FROM InstrutorDaTurma");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InstrutorDaTurma_Pessoas_InstrutorId",
                table: "InstrutorDaTurma");

            migrationBuilder.AddForeignKey(
                name: "FK_InstrutorDaTurma_Instrutores_InstrutorId",
                table: "InstrutorDaTurma",
                column: "InstrutorId",
                principalTable: "Instrutores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
