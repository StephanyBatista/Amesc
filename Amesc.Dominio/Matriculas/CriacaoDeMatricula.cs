using Amesc.Dominio.Cursos;
using Amesc.Dominio.Pessoas;

namespace Amesc.Dominio.Matriculas
{
    public class CriacaoDeMatricula
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public CriacaoDeMatricula(
            IMatriculaRepositorio matriculaRepositorio,
            ICursoAbertoRepositorio cursoAbertoRepositorio,
            IPessoaRepositorio pessoaRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
        }

        public void Criar(int idCursoAberto, int idAluno, bool estaPago, string valorPagoEmString)
        {
            var aluno = _pessoaRepositorio.ObterPorId(idAluno);
            var cursoAberto = _cursoAbertoRepositorio.ObterPorId(idCursoAberto);
            decimal.TryParse(valorPagoEmString, out var valorPago);

            var matricula = new Matricula(cursoAberto, aluno, estaPago, valorPago);

            _matriculaRepositorio.Adicionar(matricula);
        }
    }
}