IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Alunos] (
    [Id] int NOT NULL IDENTITY,
    [Cpf] nvarchar(max) NULL,
    [DataDeNascimento] datetime2 NOT NULL,
    [MidiaSocial] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [OrgaoEmissorDoRg] nvarchar(max) NULL,
    [RegistroProfissional] nvarchar(max) NULL,
    [Rg] nvarchar(max) NULL,
    [Telefone] nvarchar(max) NULL,
    [TipoDePublico] nvarchar(max) NULL,
    [Endereco_Bairro] nvarchar(max) NULL,
    [Endereco_Cidade] nvarchar(max) NULL,
    [Endereco_Complemento] nvarchar(max) NULL,
    [Endereco_Estado] nvarchar(max) NULL,
    [Endereco_Logradouro] nvarchar(max) NULL,
    [Endereco_Numero] nvarchar(max) NULL,
    CONSTRAINT [PK_Alunos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [Name] nvarchar(256) NULL,
    [NormalizedName] nvarchar(256) NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [ConcurrencyStamp] nvarchar(max) NULL,
    [Email] nvarchar(256) NULL,
    [EmailConfirmed] bit NOT NULL,
    [LockoutEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset NULL,
    [NormalizedEmail] nvarchar(256) NULL,
    [NormalizedUserName] nvarchar(256) NULL,
    [PasswordHash] nvarchar(max) NULL,
    [PhoneNumber] nvarchar(max) NULL,
    [PhoneNumberConfirmed] bit NOT NULL,
    [SecurityStamp] nvarchar(max) NULL,
    [TwoFactorEnabled] bit NOT NULL,
    [UserName] nvarchar(256) NULL,
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Cursos] (
    [Id] int NOT NULL IDENTITY,
    [Codigo] nvarchar(max) NULL,
    [Descricao] nvarchar(max) NULL,
    [Nome] nvarchar(max) NULL,
    [PeriodoValidoEmAno] int NULL,
    [PrecoSugerido] decimal(18, 2) NOT NULL,
    [Requisitos] nvarchar(max) NULL,
    CONSTRAINT [PK_Cursos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [ClaimType] nvarchar(max) NULL,
    [ClaimValue] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max) NULL,
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserRoles] (
    [UserId] nvarchar(450) NOT NULL,
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY ([UserId], [RoleId]),
    CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max) NULL,
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name]),
    CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [CursosAbertos] (
    [Id] int NOT NULL IDENTITY,
    [CursoId] int NULL,
    [Empresa] nvarchar(max) NULL,
    [FimDoCurso] datetime2 NOT NULL,
    [InicioDoCurso] datetime2 NOT NULL,
    [PeriodoFinalParaMatricula] datetime2 NULL,
    [PeriodoInicialParaMatricula] datetime2 NULL,
    [Preco] decimal(18, 2) NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_CursosAbertos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CursosAbertos_Cursos_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Cursos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PublicoAlvoParaCurso] (
    [Id] int NOT NULL IDENTITY,
    [CursoId] int NULL,
    [Nome] nvarchar(max) NULL,
    CONSTRAINT [PK_PublicoAlvoParaCurso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PublicoAlvoParaCurso_Cursos_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Cursos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [Matriculas] (
    [Id] int NOT NULL IDENTITY,
    [AlunoId] int NULL,
    [CursoAbertoId] int NULL,
    [DataDeCriacao] datetime2 NOT NULL,
    [EstaPago] bit NOT NULL,
    [Ip] nvarchar(max) NULL,
    [NotaDoAlunoNoCurso] real NULL,
    [Observacao] nvarchar(max) NULL,
    [StatusDaAprovacao] int NOT NULL,
    CONSTRAINT [PK_Matriculas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Matriculas_Alunos_AlunoId] FOREIGN KEY ([AlunoId]) REFERENCES [Alunos] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Matriculas_CursosAbertos_CursoAbertoId] FOREIGN KEY ([CursoAbertoId]) REFERENCES [CursosAbertos] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE INDEX [IX_CursosAbertos_CursoId] ON [CursosAbertos] ([CursoId]);

GO

CREATE INDEX [IX_Matriculas_AlunoId] ON [Matriculas] ([AlunoId]);

GO

CREATE INDEX [IX_Matriculas_CursoAbertoId] ON [Matriculas] ([CursoAbertoId]);

GO

CREATE INDEX [IX_PublicoAlvoParaCurso_CursoId] ON [PublicoAlvoParaCurso] ([CursoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170816010813_MigracaoInicial', N'2.0.0-rtm-26452');

GO

insert into [dbo].[AspNetRoles] values ('BD2AF962-6AB3-4D28-A902-0A8511750AB1', null, 'Admin', 'Admin');
                                insert into [dbo].[AspNetRoles] values ('813F9DB8-8601-4C82-BCE3-D122BC3E3AB9', null, 'Manager', 'Manager');
                                insert into [dbo].[AspNetRoles] values ('F2493BA0-B8CA-4E97-A882-DEA90B9E1728', null, 'Operation', 'Operation');

GO

insert into [AspNetUsers] values
                ('6d9a6ca2-9d24-4ca2-ad4b-6265a818d7d4', 0, '7beea230-7f9d-4cd5-970b-37e9fa8f4347', 'admin@admin.com', 0, 1, null, 'ADMIN@ADMIN.COM', 'ADMIN@ADMIN.COM', 'AQAAAAEAACcQAAAAEIIWoviAu641wICvbFTecu/e8tUNiQXxYQ9JaEUXLYmdcSrSS6OnOmJg1U6kxQgGbQ==', null, 0, 'cebc5f87-b136-4c12-8dff-7bb65d499f35', 0, 'admin@admin.com')

GO

insert into [AspNetUserRoles] values ('6d9a6ca2-9d24-4ca2-ad4b-6265a818d7d4', 'BD2AF962-6AB3-4D28-A902-0A8511750AB1')

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170816010814_CriarUsuarioAdmin', N'2.0.0-rtm-26452');

GO

