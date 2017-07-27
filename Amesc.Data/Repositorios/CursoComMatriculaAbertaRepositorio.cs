using System.Collections.Generic;
using System.Linq;
using Amesc.Data.Contexts;
using Amesc.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Repositorios
{
    public class CursoComMatriculaAbertaRepositorio : RepositorioBase<CursoComMatriculaAberta>, ICursoComMatriculaAbertaRepositorio
    {
        public CursoComMatriculaAbertaRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override CursoComMatriculaAberta ObterPorId(int id)
        {
            var query = Context.Set<CursoComMatriculaAberta>().Include(p => p.Curso).Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public List<CursoComMatriculaAberta> ListarPorCurso(int idCurso)
        {
            var query = Context.Set<CursoComMatriculaAberta>().Include(p => p.Curso).Where(entidade => entidade.Curso.Id == idCurso);
            return query.Any() ? query.ToList() : new List<CursoComMatriculaAberta>();
        }
    }
}
