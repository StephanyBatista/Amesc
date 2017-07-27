using System.Collections.Generic;

namespace Amesc.Dominio.Cursos
{
    public interface ICursoComMatriculaAbertaRepositorio : IRepositorio<CursoComMatriculaAberta>
    {
        List<CursoComMatriculaAberta> ListarPorCurso(int idCurso);
    }
}
