using System.Collections.Generic;
using System.Linq;
using Amesc.Data.Contexts;
using Amesc.Dominio.Cursos;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Repositorios
{
    public class CursoRepositorio : RepositorioBase<Curso>, ICursoRepositorio
    {
        public CursoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override Curso ObterPorId(int id)
        {
            var query = Context.Set<Curso>().Include(p => p.PublicosAlvo).Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public IEnumerable<Curso> ConsultarPorNome(string nome)
        {
            var query = Context.Set<Curso>().Where(entidade => entidade.Nome.ToUpper().Contains(nome.ToUpper()));
            return query.Any() ? query.ToList() : new List<Curso>();
        }
    }
}
