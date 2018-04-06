using System.Collections.Generic;
using System.Linq;
using Amesc.Data.Contexts;
using Amesc.Dominio.Cursos.Instrutores;

namespace Amesc.Data.Repositorios
{
    public class InstrutorRepositorio : RepositorioBase<Instrutor>, IInstrutorRepositorio
    {
        public InstrutorRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override Instrutor ObterPorId(int id)
        {
            var query = Context.Set<Instrutor>().Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public IEnumerable<Instrutor> ConsultarPorNome(string nome)
        {
            var query = Context.Set<Instrutor>().Where(entidade => entidade.Nome.ToUpper().Contains(nome.ToUpper()));
            return query.Any() ? query.ToList() : new List<Instrutor>();
        }
    }
}
