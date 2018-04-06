using System.Collections.Generic;
using System.Linq;
using Amesc.Data.Contexts;
using Amesc.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Repositorios
{
    public class CursoAbertoRepositorio : RepositorioBase<CursoAberto>, ICursoAbertoRepositorio
    {
        public CursoAbertoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override CursoAberto ObterPorId(int id)
        {
            var query = Context.Set<CursoAberto>()
                .Include(p => p.Instrutores)
                .ThenInclude(i => i.Instrutor)
                .Include(p => p.Curso)
                .Include(p => p.Curso.PublicosAlvo)
                .Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public override List<CursoAberto> Consultar()
        {
            var query = Context.Set<CursoAberto>().Include(p => p.Curso);
            return query.Any() ? query.ToList() : new List<CursoAberto>();
        }

        public List<CursoAberto> ListarPorCurso(int idCurso)
        {
            var query = Context.Set<CursoAberto>().Include(p => p.Curso).Where(entidade => entidade.Curso.Id == idCurso);
            return query.Any() ? query.ToList() : new List<CursoAberto>();
        }
    }
}
