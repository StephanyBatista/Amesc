using System.Collections.Generic;

namespace Amesc.Dominio.Cursos
{
    public interface ICursoRepositorio : IRepositorio<Curso>
    {
        IEnumerable<Curso> ConsultarPorNome(string nome);
    }
}
