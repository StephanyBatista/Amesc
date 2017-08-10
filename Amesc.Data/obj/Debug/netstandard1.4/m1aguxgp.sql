ALTER TABLE [Curso] ADD [Codigo] nvarchar(max);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20170810020925_AddCodigoEmCurso', N'1.1.2');

GO

