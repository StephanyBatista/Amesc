using System.Collections.Generic;
using System.Linq;
using Amesc.Data.Contexts;
using Amesc.Dominio.Pessoas;
using Microsoft.EntityFrameworkCore;

namespace Amesc.Data.Repositorios
{
    public class PessoaRepositorio : RepositorioBase<Pessoa>, IPessoaRepositorio
    {
        public PessoaRepositorio(ApplicationDbContext context) : base(context)
        {
        }

        public override Pessoa ObterPorId(int id)
        {
            var query = Context.Set<Pessoa>().Include(p => p.Endereco).Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public IEnumerable<Pessoa> ConsultarPorNome(string nome)
        {
            var query = Context.Set<Pessoa>().Include(p => p.Endereco).Where(entidade => entidade.Nome.ToUpper().Contains(nome.ToUpper()));
            return query.Any() ? query.ToList() : new List<Pessoa>();
        }

        public IEnumerable<Pessoa> ConsultarPorCpf(string cpf)
        {
            var query = Context.Set<Pessoa>().Include(p => p.Endereco).Where(entidade => entidade.Cpf == cpf);
            return query.Any() ? query.ToList() : new List<Pessoa>();
        }
    }
}
