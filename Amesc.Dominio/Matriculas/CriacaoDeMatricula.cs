using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;

namespace Amesc.Dominio.Matriculas
{
    public class CriacaoDeMatricula
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;
        private readonly IAlunoRepositorio _alunoRepositorio;

        public CriacaoDeMatricula(
            IMatriculaRepositorio matriculaRepositorio,
            ICursoAbertoRepositorio cursoAbertoRepositorio,
            IAlunoRepositorio alunoRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _alunoRepositorio = alunoRepositorio;
        }

        public void Criar(int idCursoAberto, int idAluno, bool estaPago, string valorPagoEmString)
        {
            var aluno = _alunoRepositorio.ObterPorId(idAluno);
            var cursoAberto = _cursoAbertoRepositorio.ObterPorId(idCursoAberto);
            decimal.TryParse(valorPagoEmString, out var valorPago);

            var matricula = new Matricula(cursoAberto, aluno, estaPago, valorPago);

            _matriculaRepositorio.Adicionar(matricula);
        }
    }
}