IF OBJECT_ID(N'__EFMigrationsHistory') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [AspNetUsers] (
    [Id] nvarchar(450) NOT NULL,
    [AccessFailedCount] int NOT NULL,
    [ConcurrencyStamp] nvarchar(max),
    [Email] nvarchar(256),
    [EmailConfirmed] bit NOT NULL,
    [LockoutEnabled] bit NOT NULL,
    [LockoutEnd] datetimeoffset,
    [NormalizedEmail] nvarchar(256),
    [NormalizedUserName] nvarchar(256),
    [PasswordHash] nvarchar(max),
    [PhoneNumber] nvarchar(max),
    [PhoneNumberConfirmed] bit NOT NULL,
    [SecurityStamp] nvarchar(max),
    [TwoFactorEnabled] bit NOT NULL,
    [UserName] nvarchar(256),
    CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Endereco] (
    [Id] int NOT NULL IDENTITY,
    [Bairro] nvarchar(max),
    [Cidade] nvarchar(max),
    [Complemento] nvarchar(max),
    [Estado] nvarchar(max),
    [Logradouro] nvarchar(max),
    [Numero] nvarchar(max),
    CONSTRAINT [PK_Endereco] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Curso] (
    [Id] int NOT NULL IDENTITY,
    [Codigo] nvarchar(max),
    [Descricao] nvarchar(max),
    [Nome] nvarchar(max),
    [PeriodoValidoEmAno] int,
    [PrecoSugerido] decimal(18, 2) NOT NULL,
    [Requisitos] nvarchar(max),
    CONSTRAINT [PK_Curso] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetRoles] (
    [Id] nvarchar(450) NOT NULL,
    [ConcurrencyStamp] nvarchar(max),
    [Name] nvarchar(256),
    [NormalizedName] nvarchar(256),
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [AspNetUserTokens] (
    [UserId] nvarchar(450) NOT NULL,
    [LoginProvider] nvarchar(450) NOT NULL,
    [Name] nvarchar(450) NOT NULL,
    [Value] nvarchar(max),
    CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY ([UserId], [LoginProvider], [Name])
);

GO

CREATE TABLE [AspNetUserClaims] (
    [Id] int NOT NULL IDENTITY,
    [ClaimType] nvarchar(max),
    [ClaimValue] nvarchar(max),
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [AspNetUserLogins] (
    [LoginProvider] nvarchar(450) NOT NULL,
    [ProviderKey] nvarchar(450) NOT NULL,
    [ProviderDisplayName] nvarchar(max),
    [UserId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY ([LoginProvider], [ProviderKey]),
    CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Aluno] (
    [Id] int NOT NULL IDENTITY,
    [Cpf] nvarchar(max),
    [DataDeNascimento] datetime2 NOT NULL,
    [EnderecoId] int,
    [MidiaSocial] nvarchar(max),
    [Nome] nvarchar(max),
    [OrgaoEmissorDoRg] nvarchar(max),
    [RegistroProfissional] nvarchar(max),
    [Rg] nvarchar(max),
    [Telefone] nvarchar(max),
    [TipoDePublico] nvarchar(max),
    CONSTRAINT [PK_Aluno] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Aluno_Endereco_EnderecoId] FOREIGN KEY ([EnderecoId]) REFERENCES [Endereco] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [CursoAberto] (
    [Id] int NOT NULL IDENTITY,
    [CursoId] int,
    [Empresa] nvarchar(max),
    [FimDoCurso] datetime2 NOT NULL,
    [InicioDoCurso] datetime2 NOT NULL,
    [PeriodoFinalParaMatricula] datetime2,
    [PeriodoInicialParaMatricula] datetime2,
    [Preco] decimal(18, 2) NOT NULL,
    [Tipo] int NOT NULL,
    CONSTRAINT [PK_CursoAberto] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_CursoAberto_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Curso] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [PublicoAlvoParaCurso] (
    [Id] int NOT NULL IDENTITY,
    [CursoId] int,
    [Nome] nvarchar(max),
    CONSTRAINT [PK_PublicoAlvoParaCurso] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_PublicoAlvoParaCurso_Curso_CursoId] FOREIGN KEY ([CursoId]) REFERENCES [Curso] ([Id]) ON DELETE NO ACTION
);

GO

CREATE TABLE [AspNetRoleClaims] (
    [Id] int NOT NULL IDENTITY,
    [ClaimType] nvarchar(max),
    [ClaimValue] nvarchar(max),
    [RoleId] nvarchar(450) NOT NULL,
    CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [AspNetRoles] ([Id]) ON DELETE CASCADE
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

CREATE TABLE [Matricula] (
    [Id] int NOT NULL IDENTITY,
    [AlunoId] int,
    [CursoAbertoId] int,
    [DataDeCriacao] datetime2 NOT NULL,
    [EstaPago] bit NOT NULL,
    [NotaDoAlunoNoCurso] real,
    [Observacao] nvarchar(max),
    CONSTRAINT [PK_Matricula] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Matricula_Aluno_AlunoId] FOREIGN KEY ([AlunoId]) REFERENCES [Aluno] ([Id]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Matricula_CursoAberto_CursoAbertoId] FOREIGN KEY ([CursoAbertoId]) REFERENCES [CursoAberto] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [EmailIndex] ON [AspNetUsers] ([NormalizedEmail]);

GO

CREATE UNIQUE INDEX [UserNameIndex] ON [AspNetUsers] ([NormalizedUserName]) WHERE [NormalizedUserName] IS NOT NULL;

GO

CREATE INDEX [IX_Aluno_EnderecoId] ON [Aluno] ([EnderecoId]);

GO

CREATE INDEX [IX_CursoAberto_CursoId] ON [CursoAberto] ([CursoId]);

GO

CREATE INDEX [IX_PublicoAlvoParaCurso_CursoId] ON [PublicoAlvoParaCurso] ([CursoId]);

GO

CREATE INDEX [IX_Matricula_AlunoId] ON [Matricula] ([AlunoId]);

GO

CREATE INDEX [IX_Matricula_CursoAbertoId] ON [Matricula] ([CursoAbertoId]);

GO

CREATE UNIQUE INDEX [RoleNameIndex] ON [AspNetRoles] ([NormalizedName]) WHERE [NormalizedName] IS NOT NULL;

GO

CREATE INDEX [IX_AspNetRoleClaims_RoleId] ON [AspNetRoleClaims] ([RoleId]);

GO

CREATE INDEX [IX_AspNetUserClaims_UserId] ON [AspNetUserClaims] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserLogins_UserId] ON [AspNetUserLogins] ([UserId]);

GO

CREATE INDEX [IX_AspNetUserRoles_RoleId] ON [AspNetUserRoles] ([RoleId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170815010837_MigracaoInicial', N'1.1.2');

GO

insert into [dbo].[AspNetRoles] values ('BD2AF962-6AB3-4D28-A902-0A8511750AB1', null, 'Admin', 'Admin');
                                insert into [dbo].[AspNetRoles] values ('813F9DB8-8601-4C82-BCE3-D122BC3E3AB9', null, 'Manager', 'Manager');
                                insert into [dbo].[AspNetRoles] values ('F2493BA0-B8CA-4E97-A882-DEA90B9E1728', null, 'Operation', 'Operation');;

GO

insert into [AspNetUsers] values
                ('6d9a6ca2-9d24-4ca2-ad4b-6265a818d7d4', 0, '7beea230-7f9d-4cd5-970b-37e9fa8f4347', 'admin@admin.com', 0, 1, null, 'ADMIN@ADMIN.COM', 'ADMIN@ADMIN.COM', 'AQAAAAEAACcQAAAAEIIWoviAu641wICvbFTecu/e8tUNiQXxYQ9JaEUXLYmdcSrSS6OnOmJg1U6kxQgGbQ==', null, 0, 'cebc5f87-b136-4c12-8dff-7bb65d499f35', 0, 'admin@admin.com');

GO

insert into [AspNetUserRoles] values ('6d9a6ca2-9d24-4ca2-ad4b-6265a818d7d4', 'BD2AF962-6AB3-4D28-A902-0A8511750AB1');

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170815010838_CriarUsuarioAdmin', N'1.1.2');

GO

