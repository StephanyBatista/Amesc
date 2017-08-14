using System.Collections.Generic;
using System.Linq;
using Amesc.Data.Contexts;
using Amesc.Dominio.Alunos;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Repositorios
{
    public class AlunoRepositorio : RepositorioBase<Aluno>, IAlunoRepositorio
    {
        public AlunoRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override Aluno ObterPorId(int id)
        {
            var query = Context.Set<Aluno>().Include(p => p.Endereco).Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public IEnumerable<Aluno> ConsultarPorNome(string nome)
        {
            var query = Context.Set<Aluno>().Include(p => p.Endereco).Where(entidade => entidade.Nome.ToUpper().Contains(nome.ToUpper()));
            return query.Any() ? query.ToList() : new List<Aluno>();
        }
    }
}
