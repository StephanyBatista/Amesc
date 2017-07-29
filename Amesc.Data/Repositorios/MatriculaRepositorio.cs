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
                .Include(p => p.Aluno)
                .Include(p => p.CursoAberto)
                .Include(p => p.CursoAberto.Curso)
                .Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public override List<Matricula> Consultar()
        {
            var query = Context.Set<Matricula>()
                .Include(p => p.Aluno)
                .Include(p => p.CursoAberto)
                .Include(p => p.CursoAberto.Curso);
            return query.Any() ? query.OrderBy(m => m.DataDeCriacao).ToList() : new List<Matricula>();
        }
    }
}
