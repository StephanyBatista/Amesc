using System.Linq;
using Amesc.Data.Contexts;
using Amesc.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Repositorios
{
    public class CursoRepositorio : RepositorioBase<Curso>
    {
        public CursoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override Curso ObterPorId(int id)
        {
            var query = Context.Set<Curso>().Include(p => p.PublicosAlvo).Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }
    }
}
