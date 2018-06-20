using System.Collections.Generic;
using System.Linq;
using Amesc.Data.Contexts;
using Amesc.Dominio.Matriculas;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Repositorios
{
    public class MatriculaRepositorio : RepositorioBase<Matricula>, IMatriculaRepositorio
    {
        public MatriculaRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override Matricula ObterPorId(int id)
        {
            var query = Context.Set<Matricula>()
                .Include(p => p.Pessoa)
                .Include(p => p.CursoAberto)
                .Include(p => p.CursoAberto.Curso)
                .Include(p => p.ComoFicouSabendo)
                .Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public override List<Matricula> Consultar()
        {
            var query = Context.Set<Matricula>()
                .Include(p => p.Pessoa)
                .Include(p => p.CursoAberto)
                .Include(p => p.CursoAberto.Curso);
            return query.Any() ? query.OrderBy(m => m.DataDeCriacao).ToList() : new List<Matricula>();
        }

        public List<Matricula> ConsultarPor(string nomeDoAluno, int? turmaId, bool cancelada, bool pago, bool validadeExpirada)
        {
            var select = Context.Set<Matricula>()
                .Include(p => p.Pessoa)
                .Include(p => p.CursoAberto)
                .Include(p => p.CursoAberto.Curso);

            var query = select.AsQueryable();
            if(!string.IsNullOrEmpty(nomeDoAluno))
                query = query.Where(p => p.Pessoa.Nome.Contains(nomeDoAluno));
            
            if(turmaId.HasValue)
                query = query.Where(p => p.CursoAberto.Id == turmaId.Value);

            if(!pago)
                query = query.Where(p => p.EstaPago);

            query = cancelada ? query.Where(p => p.Cancelada) : query.Where(p => !p.Cancelada);

            return query.Any() ? query.OrderBy(m => m.DataDeCriacao).ToList() : new List<Matricula>();
        }

        public List<Matricula> ConsultarTodosAlunosPor(int turmaId, int ano)
        {
            return Context.Set<Matricula>()
                .Where(m => m.CursoAberto.Id == turmaId && m.DataDeCriacao.Year == ano && !m.Cancelada)
                .Include(p => p.Pessoa)
                .ThenInclude(p => p.Endereco)
                .Include(p => p.CursoAberto)
                .Include(p => p.CursoAberto.Curso)
                .ToList();
        }
    }
}
