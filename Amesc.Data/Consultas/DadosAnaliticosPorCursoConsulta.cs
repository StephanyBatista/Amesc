using System.Collections.Generic;
using System.Data.Common;
using System.Threading.Tasks;
using Amesc.Data.Contexts;
using Amesc.Dominio._Consultas;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Consultas
{
    public class DadosAnaliticosPorCursoConsulta : IDadosAnaliticosPorCursoConsulta
    {
        private readonly ApplicationDbContext _context;

        public DadosAnaliticosPorCursoConsulta(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DadosAnaliticosPorCurso> Consultar(int cursoId, int ano)
        {
            var dadosAnaliticosPorCurso = new DadosAnaliticosPorCurso();
            using (var connection = _context.Database.GetDbConnection())
            {
                try
                {
                    await connection.OpenAsync();
                    using (var command = connection.CreateCommand())
                    {
                        dadosAnaliticosPorCurso.AprovacaoPorCurso = await AprovacaoPorCurso(command, cursoId, ano);
                        dadosAnaliticosPorCurso.PublicoAlvoPorCursos = await PublicoAlvo(command, cursoId, ano);
                        dadosAnaliticosPorCurso.CidadesDosAlunosPorCursos = await CidadesDosAlunosPorCurso(command, cursoId, ano);
                    }
                }
                finally
                {
                    connection.Close();
                }
            }

            return dadosAnaliticosPorCurso;
        }

        private async Task<AprovacaoPorCurso> AprovacaoPorCurso(DbCommand command, int cursoId, int ano)
        {
            var query = 
                $@"select
                    c.id,
                    c.nome,
                    (select count(*) from matriculas m inner join CursosAbertos t on m.CursoAbertoId = t.id and t.CursoId = c.id where 
                        StatusDaAprovacao = 1 and year(InicioDoCurso) = {ano} and Cancelada = 0) as aprovados,
                    (select count(*) from matriculas m inner join CursosAbertos t on m.CursoAbertoId = t.id and t.CursoId = c.id 
                        where StatusDaAprovacao = 2 and year(InicioDoCurso) = {ano} and Cancelada = 0) as reprovados,
                    (select count(*) from matriculas m inner join CursosAbertos t on m.CursoAbertoId = t.id and t.CursoId = c.id 
                        where StatusDaAprovacao = 0 and year(InicioDoCurso) = {ano} and Cancelada = 0) as semNotas
                FROM
                    Cursos c
                WHERE c.Id = {cursoId}";

            command.CommandText = query;
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (!reader.HasRows) return null;
                if (await reader.ReadAsync() &&
                   (reader.GetInt32(2) > 0 || reader.GetInt32(3) > 0 || reader.GetInt32(4) > 0))
                    return new AprovacaoPorCurso
                    {
                        QuantidadeDeAprovados = reader.GetInt32(2),
                        QuantidadeDeReprovados = reader.GetInt32(3),
                        QuantidadeDeSemNotas = reader.GetInt32(4)
                    };
                return null;
            }
        }

        private async Task<List<PublicoAlvoPorCurso>> PublicoAlvo(DbCommand command, int cursoId, int ano)
        {
            var publicoAlvosPorCurso = new List<PublicoAlvoPorCurso>();

            var query =
                $@"select
                    distinct
                    c.id,
                    c.nome,
                    p.TipoDePublico,
                    (select count(*)
                        from Matriculas m2
                        inner join CursosAbertos t2
                        on m2.CursoAbertoId = t2.Id
                        inner join Pessoas p2
                        on m2.PessoaId = p2.Id
                        where t2.CursoId = c.id and p2.TipoDePublico = p.TipoDePublico and Cancelada = 0)
                FROM
                    Cursos c
                    inner join CursosAbertos t
                    on c.Id = t.CursoId
                    inner join Matriculas m
                    on t.id = m.CursoAbertoId
                    inner join Pessoas p
                    on m.PessoaId = p.Id
                WHERE c.Id = {cursoId} and year(InicioDoCurso) = {ano} and Cancelada = 0";

            command.CommandText = query;
            using (var reader = await command.ExecuteReaderAsync())
            {
                if(reader.HasRows)
                    while (await reader.ReadAsync())
                        publicoAlvosPorCurso.Add(new PublicoAlvoPorCurso
                        {
                            Nome = reader.GetString(2),
                            Quantidade = reader.GetInt32(3)
                        });
            }

            return publicoAlvosPorCurso;
        }

        private async Task<List<CidadesDosAlunosPorCurso>> CidadesDosAlunosPorCurso(DbCommand command, int cursoId, int ano)
        {
            var cidadesDosAlunosPorCursos = new List<CidadesDosAlunosPorCurso>();

            var query =
                $@"select
                    distinct
                    c.id,
                    c.nome,
                    p.Endereco_Cidade,
                    (select count(*)
                    from Matriculas m2
                    inner join CursosAbertos t2
                    on m2.CursoAbertoId = t2.Id
                    inner join Pessoas p2
                    on m2.PessoaId = p2.Id
                    where t2.CursoId = c.id and p2.Endereco_Cidade = p.Endereco_Cidade and Cancelada = 0)
                FROM
                    Cursos c
                    inner join CursosAbertos t
                    on c.Id = t.CursoId
                    inner join Matriculas m
                    on t.id = m.CursoAbertoId
                    inner join Pessoas p
                    on m.PessoaId = p.Id
                WHERE c.Id = {cursoId} and year(InicioDoCurso) = {ano} and Cancelada = 0";

            command.CommandText = query;
            using (var reader = await command.ExecuteReaderAsync())
            {
                if (reader.HasRows)
                    while (await reader.ReadAsync())
                        cidadesDosAlunosPorCursos.Add(new CidadesDosAlunosPorCurso
                        {
                            Nome = reader.GetString(2),
                            Quantidade = reader.GetInt32(3)
                        });
            }

            return cidadesDosAlunosPorCursos;
        }
    }
}
