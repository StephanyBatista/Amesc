using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Amesc.Data.Migrations
{
    public partial class MigracaoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contato",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Endereco = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contato", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    PeriodoValidoEmAno = table.Column<int>(nullable: true),
                    PrecoSugerido = table.Column<decimal>(nullable: false),
                    Requisitos = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContatoId = table.Column<int>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    TipoDePublico = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_Contato_ContatoId",
                        column: x => x.ContatoId,
                        principalTable: "Contato",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CursoAberto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursoId = table.Column<int>(nullable: true),
                    DataDeAbertura = table.Column<DateTime>(nullable: false),
                    DataDeFechamento = table.Column<DateTime>(nullable: false),
                    DataDoCurso = table.Column<DateTime>(nullable: false),
                    Preco = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CursoAberto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CursoAberto_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublicoAlvoParaCurso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CursoId = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicoAlvoParaCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublicoAlvoParaCurso_Curso_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Matricula",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AlunoId = table.Column<int>(nullable: true),
                    CursoAbertoId = table.Column<int>(nullable: true),
                    DataDeCriacao = table.Column<DateTime>(nullable: false),
                    EstaPago = table.Column<bool>(nullable: false),
                    NotaDoAlunoNoCurso = table.Column<float>(nullable: true),
                    Observacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matricula", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matricula_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matricula_CursoAberto_CursoAbertoId",
                        column: x => x.CursoAbertoId,
                        principalTable: "CursoAberto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_ContatoId",
                table: "Aluno",
                column: "ContatoId");

            migrationBuilder.CreateIndex(
                name: "IX_CursoAberto_CursoId",
                table: "CursoAberto",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_PublicoAlvoParaCurso_CursoId",
                table: "PublicoAlvoParaCurso",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_AlunoId",
                table: "Matricula",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_Matricula_CursoAbertoId",
                table: "Matricula",
                column: "CursoAbertoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PublicoAlvoParaCurso");

            migrationBuilder.DropTable(
                name: "Matricula");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "CursoAberto");

            migrationBuilder.DropTable(
                name: "Contato");

            migrationBuilder.DropTable(
                name: "Curso");
        }
    }
}
