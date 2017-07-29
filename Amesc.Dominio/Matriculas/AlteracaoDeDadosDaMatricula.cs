using Amesc.Dominio._Base;

namespace Amesc.Dominio.Matriculas
{
    public class AlteracaoDeDadosDaMatricula
    {
        private readonly IRepositorio<Matricula> _matriculaRepositorio;

        public AlteracaoDeDadosDaMatricula(IRepositorio<Matricula> matriculaRepositorio)
        {
            _matriculaRepositorio = matriculaRepositorio;
        }

        public void Alterar(int idMatricula, string observacao, float? notaDoAlunoNoCurso)
        {
            var matricula = _matriculaRepositorio.ObterPorId(idMatricula);
            ExcecaoDeDominio.Quando(matricula == null, "Matricula não encontrada");

            if(!string.IsNullOrEmpty(observacao))
                matricula.AdicionarObservacao(observacao);
            if(notaDoAlunoNoCurso.HasValue)
                matricula.AdicionarNotaDoAlunoNoCurso(notaDoAlunoNoCurso.Value);
        }
    }
}