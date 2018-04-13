﻿// <auto-generated />
using Amesc.Data.Contexts;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio.Matriculas;
using Amesc.Dominio.Pessoas;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace Amesc.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180413000430_AdicionarComoFicouSabendo")]
    partial class AdicionarComoFicouSabendo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
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
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
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

                    b.ToTable("Cursos");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.CursoAberto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Codigo");

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

                    b.ToTable("CursosAbertos");
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

            modelBuilder.Entity("Amesc.Dominio.Cursos.Turma.ComoFicouSabendo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("ComoFicouSabendo");
                });

            modelBuilder.Entity("Amesc.Dominio.Cursos.Turma.InstrutorDaTurma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Cargo");

                    b.Property<int?>("CursoAbertoId");

                    b.Property<int?>("InstrutorId");

                    b.HasKey("Id");

                    b.HasIndex("CursoAbertoId");

                    b.HasIndex("InstrutorId");

                    b.ToTable("InstrutorDaTurma");
                });

            modelBuilder.Entity("Amesc.Dominio.Matriculas.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("Cancelada");

                    b.Property<int?>("ComoFicouSabendoId");

                    b.Property<int?>("CursoAbertoId");

                    b.Property<DateTime>("DataDeCriacao");

                    b.Property<bool>("EstaPago");

                    b.Property<bool>("Ip");

                    b.Property<float?>("NotaDoAlunoNoCurso");

                    b.Property<string>("Observacao");

                    b.Property<int?>("PessoaId");

                    b.Property<int>("StatusDaAprovacao");

                    b.Property<decimal?>("ValorPago");

                    b.HasKey("Id");

                    b.HasIndex("ComoFicouSabendoId");

                    b.HasIndex("CursoAbertoId");

                    b.HasIndex("PessoaId");

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("Amesc.Dominio.Pessoas.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Especialidade");

                    b.Property<string>("MidiaSocial");

                    b.Property<string>("Nome");

                    b.Property<string>("OrgaoEmissorDoRg");

                    b.Property<string>("RegistroProfissional");

                    b.Property<string>("Rg");

                    b.Property<string>("Telefone");

                    b.Property<int>("TipoDePessoa");

                    b.Property<string>("TipoDePublico");

                    b.HasKey("Id");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
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
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
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

            modelBuilder.Entity("Amesc.Dominio.Cursos.Turma.InstrutorDaTurma", b =>
                {
                    b.HasOne("Amesc.Dominio.Cursos.CursoAberto")
                        .WithMany("Instrutores")
                        .HasForeignKey("CursoAbertoId");

                    b.HasOne("Amesc.Dominio.Pessoas.Pessoa", "Instrutor")
                        .WithMany()
                        .HasForeignKey("InstrutorId");
                });

            modelBuilder.Entity("Amesc.Dominio.Matriculas.Matricula", b =>
                {
                    b.HasOne("Amesc.Dominio.Cursos.Turma.ComoFicouSabendo", "ComoFicouSabendo")
                        .WithMany()
                        .HasForeignKey("ComoFicouSabendoId");

                    b.HasOne("Amesc.Dominio.Cursos.CursoAberto", "CursoAberto")
                        .WithMany()
                        .HasForeignKey("CursoAbertoId");

                    b.HasOne("Amesc.Dominio.Pessoas.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId");
                });

            modelBuilder.Entity("Amesc.Dominio.Pessoas.Pessoa", b =>
                {
                    b.OwnsOne("Amesc.Dominio.Pessoas.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("PessoaId");

                            b1.Property<string>("Bairro");

                            b1.Property<string>("Cep");

                            b1.Property<string>("Cidade");

                            b1.Property<string>("Complemento");

                            b1.Property<string>("Estado");

                            b1.Property<string>("Logradouro");

                            b1.Property<string>("Numero");

                            b1.ToTable("Pessoas");

                            b1.HasOne("Amesc.Dominio.Pessoas.Pessoa")
                                .WithOne("Endereco")
                                .HasForeignKey("Amesc.Dominio.Pessoas.Endereco", "PessoaId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Amesc.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Amesc.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Amesc.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Amesc.Data.Identity.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
