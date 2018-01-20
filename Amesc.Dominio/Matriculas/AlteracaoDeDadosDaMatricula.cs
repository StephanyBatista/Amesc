using System;
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

        public void Alterar(int idMatricula, string observacao, float? notaDoAlunoNoCurso, string statusDaAprovacaoEmString, string ip)
        {
            var matricula = _matriculaRepositorio.ObterPorId(idMatricula);
            ExcecaoDeDominio.Quando(matricula == null, "Matricula não encontrada");

            if(!string.IsNullOrEmpty(observacao))
                matricula.AdicionarObservacao(observacao);
            
            if(notaDoAlunoNoCurso.HasValue)
            {
                ExcecaoDeDominio.Quando(!Enum.TryParse(statusDaAprovacaoEmString, out StatusDaAprovacaoDaMatricula status), "Status da aprovação é inválido");
                matricula.AdicionarNotaDoAlunoNoCurso(notaDoAlunoNoCurso.Value, status);
            }
        }
    }
}