using System.Collections.Generic;

namespace Amesc.Dominio.Alunos
{
    public interface IAlunoRepositorio : IRepositorio<Aluno>
    {
        IEnumerable<Aluno> ConsultarPorNome(string nome);
    }
}
