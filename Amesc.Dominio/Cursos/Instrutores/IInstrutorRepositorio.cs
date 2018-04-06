using System.Collections.Generic;

namespace Amesc.Dominio.Cursos.Instrutores
{
    public interface IInstrutorRepositorio : IRepositorio<Instrutor>
    {
        IEnumerable<Instrutor> ConsultarPorNome(string nome);
    }
}