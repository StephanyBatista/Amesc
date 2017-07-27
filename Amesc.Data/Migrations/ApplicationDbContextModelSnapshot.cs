using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Amesc.Data.Contexts;

namespace Amesc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Amesc.Dominio.Alunos.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContatoId");

                    b.Property<string>("Cpf");

                    b.Property<string>("Nome");

                    b.Property<string>("TipoDePublico");

                    b.HasKey("Id");

                    b.HasIndex("ContatoId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Amesc.Dominio.Alunos.Contato", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Endereco");

                    b.Property<string>("Telefone");

                    b.HasKey("Id");

                    b.ToTable("Contato");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<int?>("PeriodoValidoEmAno");

                    b.Property<decimal>("PrecoSugerido");

                    b.Property<string>("Requisitos");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.CursoComMatriculaAberta", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CursoId");

                    b.Property<DateTime>("DataDeAbertura");

                    b.Property<DateTime>("DataDeFechamento");

                    b.Property<DateTime>("DataDoCurso");

                    b.Property<decimal>("Preco");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("CursoComMatriculaAberta");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.PublicoAlvoParaCurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CursoId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("PublicoAlvoParaCurso");
                });

            modelBuilder.Entity("Amesc.Dominio.Alunos.Aluno", b =>
                {
                    b.HasOne("Amesc.Dominio.Alunos.Contato", "Contato")
                        .WithMany()
                        .HasForeignKey("ContatoId");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.CursoComMatriculaAberta", b =>
                {
                    b.HasOne("Amesc.Dominio.Cursos.Curso", "Curso")
                        .WithMany()
                        .HasForeignKey("CursoId");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.PublicoAlvoParaCurso", b =>
                {
                    b.HasOne("Amesc.Dominio.Cursos.Curso")
                        .WithMany("PublicosAlvo")
                        .HasForeignKey("CursoId");
                });
        }
    }
}
