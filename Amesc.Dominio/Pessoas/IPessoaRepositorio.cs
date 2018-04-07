using System.Collections.Generic;

namespace Amesc.Dominio.Pessoas
{
    public interface IPessoaRepositorio : IRepositorio<Pessoa>
    {
        IEnumerable<Pessoa> ConsultarPorNome(string nome);
        IEnumerable<Pessoa> ConsultarPorCpf(string cpf);
    }
}
