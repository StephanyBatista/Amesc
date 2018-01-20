﻿// <auto-generated />
using Amesc.Data.Contexts;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
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
    [Migration("20180120135813_AddColunaCanceladaNaMatricula")]
    partial class AddColunaCanceladaNaMatricula
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

            modelBuilder.Entity("Amesc.Dominio.Alunos.Aluno", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Cpf");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("MidiaSocial");

                    b.Property<string>("Nome");

                    b.Property<string>("OrgaoEmissorDoRg");

                    b.Property<string>("RegistroProfissional");

                    b.Property<string>("Rg");

                    b.Property<string>("Telefone");

                    b.Property<string>("TipoDePublico");

                    b.HasKey("Id");

                    b.ToTable("Alunos");
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

            modelBuilder.Entity("Amesc.Dominio.Matriculas.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("AlunoId");

                    b.Property<bool>("Cancelada");

                    b.Property<int?>("CursoAbertoId");

                    b.Property<DateTime>("DataDeCriacao");

                    b.Property<bool>("EstaPago");

                    b.Property<string>("Ip");

                    b.Property<float?>("NotaDoAlunoNoCurso");

                    b.Property<string>("Observacao");

                    b.Property<int>("StatusDaAprovacao");

                    b.Property<decimal?>("ValorPago");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.HasIndex("CursoAbertoId");

                    b.ToTable("Matriculas");
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

            modelBuilder.Entity("Amesc.Dominio.Alunos.Aluno", b =>
                {
                    b.OwnsOne("Amesc.Dominio.Alunos.Endereco", "Endereco", b1 =>
                        {
                            b1.Property<int>("AlunoId");

                            b1.Property<string>("Bairro");

                            b1.Property<string>("Cep");

                            b1.Property<string>("Cidade");

                            b1.Property<string>("Complemento");

                            b1.Property<string>("Estado");

                            b1.Property<string>("Logradouro");

                            b1.Property<string>("Numero");

                            b1.ToTable("Alunos");

                            b1.HasOne("Amesc.Dominio.Alunos.Aluno")
                                .WithOne("Endereco")
                                .HasForeignKey("Amesc.Dominio.Alunos.Endereco", "AlunoId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
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
