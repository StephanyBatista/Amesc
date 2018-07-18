using System.Collections.Generic;

namespace Amesc.Dominio.Matriculas
{
    public interface IMatriculaRepositorio : IRepositorio<Matricula>
    {
        List<Matricula> ConsultarPor(string nomeDoAluno, int? turmaId, bool cancelada, bool pago, bool validadeExpirada);
        List<Matricula> ConsultarTodosAlunosPor(int turmaId);
    }
}
