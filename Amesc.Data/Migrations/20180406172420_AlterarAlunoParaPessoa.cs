using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Amesc.Data.Migrations
{
    public partial class AlterarAlunoParaPessoa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas");

            migrationBuilder.RenameColumn("AlunoId", "Matriculas", "PessoaId");

            migrationBuilder.AddColumn<int>(
                name: "TipoDePessoa",
                table: "Alunos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.RenameTable("Alunos", null, "Pessoas");

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_PessoaId",
                table: "Matriculas",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_PessoaId",
                table: "Matriculas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Matriculas_Pessoas_PessoaId",
                table: "Matriculas");

            migrationBuilder.DropIndex(
                name: "IX_Matriculas_PessoaId",
                table: "Matriculas");

            migrationBuilder.RenameColumn("PessoaId", "Matriculas", "AlunoId");

            migrationBuilder.RenameTable("Pessoas", null, "Alunos");

            migrationBuilder.DropColumn(
                name: "TipoDePessoa",
                table: "Alunos");

            migrationBuilder.AddColumn<int>(
                name: "AlunoId",
                table: "Matriculas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Matriculas_AlunoId",
                table: "Matriculas",
                column: "AlunoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Matriculas_Alunos_AlunoId",
                table: "Matriculas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
