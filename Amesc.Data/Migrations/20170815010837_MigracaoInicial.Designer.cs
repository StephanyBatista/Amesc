using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Amesc.Data.Contexts;
using Amesc.Dominio.Cursos;

namespace Amesc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170815010837_MigracaoInicial")]
    partial class MigracaoInicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Amesc.Data.Identity.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("Amesc.Dominio.Alunos.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<int?>("EnderecoId");

                    b.Property<string>("MidiaSocial");

                    b.Property<string>("Nome");

                    b.Property<string>("OrgaoEmissorDoRg");

                    b.Property<string>("RegistroProfissional");

                    b.Property<string>("Rg");

                    b.Property<string>("Telefone");

                    b.Property<string>("TipoDePublico");

                    b.HasKey("Id");

                    b.HasIndex("EnderecoId");

                    b.ToTable("Aluno");
                });

            modelBuilder.Entity("Amesc.Dominio.Alunos.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Bairro");

                    b.Property<string>("Cidade");

                    b.Property<string>("Complemento");

                    b.Property<string>("Estado");

                    b.Property<string>("Logradouro");

                    b.Property<string>("Numero");

                    b.HasKey("Id");

                    b.ToTable("Endereco");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo");

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome");

                    b.Property<int?>("PeriodoValidoEmAno");

                    b.Property<decimal>("PrecoSugerido");

                    b.Property<string>("Requisitos");

                    b.HasKey("Id");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.CursoAberto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CursoId");

                    b.Property<string>("Empresa");

                    b.Property<DateTime>("FimDoCurso");

                    b.Property<DateTime>("InicioDoCurso");

                    b.Property<DateTime?>("PeriodoFinalParaMatricula");

                    b.Property<DateTime?>("PeriodoInicialParaMatricula");

                    b.Property<decimal>("Preco");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("CursoAberto");
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

            modelBuilder.Entity("Amesc.Dominio.Matriculas.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlunoId");

                    b.Property<int?>("CursoAbertoId");

                    b.Property<DateTime>("DataDeCriacao");

                    b.Property<bool>("EstaPago");

                    b.Property<float?>("NotaDoAlunoNoCurso");

                    b.Property<string>("Observacao");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("CursoAbertoId");

                    b.ToTable("Matricula");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Amesc.Dominio.Alunos.Aluno", b =>
                {
                    b.HasOne("Amesc.Dominio.Alunos.Endereco", "Endereco")
                        .WithMany()
                        .HasForeignKey("EnderecoId");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.CursoAberto", b =>
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

            modelBuilder.Entity("Amesc.Dominio.Matriculas.Matricula", b =>
                {
                    b.HasOne("Amesc.Dominio.Alunos.Aluno", "Aluno")
                        .WithMany()
                        .HasForeignKey("AlunoId");

                    b.HasOne("Amesc.Dominio.Cursos.CursoAberto", "CursoAberto")
                        .WithMany()
                        .HasForeignKey("CursoAbertoId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Amesc.Data.Identity.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Amesc.Data.Identity.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Amesc.Data.Identity.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
