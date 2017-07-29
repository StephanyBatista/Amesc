using System.Collections.Generic;

namespace Amesc.Dominio.Cursos
{
    public interface ICursoAbertoRepositorio : IRepositorio<CursoAberto>
    {
        List<CursoAberto> ListarPorCurso(int idCurso);
    }
}
