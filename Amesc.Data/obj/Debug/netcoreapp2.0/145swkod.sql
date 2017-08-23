ALTER TABLE [Alunos] ADD [Endereco_Cep] nvarchar(max) NULL;

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170823173628_AddCepEmEndereco', N'2.0.0-rtm-26452');

GO

