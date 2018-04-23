using System.Collections.Generic;

namespace Amesc.Dominio.Matriculas
{
    public interface IMatriculaRepositorio : IRepositorio<Matricula>
    {
        List<Matricula> ConsultarPor(string nomeDoAluno, string nomeDoCurso, bool pago, bool validadeExpirada);
        List<Matricula> ConsultarTodosAlunosPor(int turmaId);
    }
}
