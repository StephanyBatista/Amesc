using Amesc.Dominio.Cursos;
using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio.Pessoas;

namespace Amesc.Dominio.Matriculas
{
    public class CriacaoDeMatricula
    {
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IRepositorio<ComoFicouSabendo> _comoFicouSabendoRepositorio;

        public CriacaoDeMatricula(IMatriculaRepositorio matriculaRepositorio,
            ICursoAbertoRepositorio cursoAbertoRepositorio,
            IPessoaRepositorio pessoaRepositorio, 
            IRepositorio<ComoFicouSabendo> comoFicouSabendoRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _comoFicouSabendoRepositorio = comoFicouSabendoRepositorio;
        }

        public void Criar(int idCursoAberto, int idAluno, bool estaPago, string valorPagoEmString, int idComoFicouSabendo)
        {
            var aluno = _pessoaRepositorio.ObterPorId(idAluno);
            var cursoAberto = _cursoAbertoRepositorio.ObterPorId(idCursoAberto);
            var comoFicouSabendo = _comoFicouSabendoRepositorio.ObterPorId(idComoFicouSabendo);
            decimal.TryParse(valorPagoEmString, out var valorPago);

            var matricula = new Matricula(cursoAberto, aluno, estaPago, valorPago, comoFicouSabendo);

            _matriculaRepositorio.Adicionar(matricula);
        }
    }
}