using System;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Matriculas
{
    public enum StatusDaAprovacaoDaMatricula {

        Nenhum,
        Aprovado,
        Reprovado
    }
    
    public class Matricula : Entidade
    {
        public CursoAberto CursoAberto { get; private set; }
        public Aluno Aluno { get; private set; }
        public DateTime DataDeCriacao { get; private set; }
        public bool EstaPago { get; private set; }
        public string Observacao { get; private set; }
        public float? NotaDoAlunoNoCurso { get; private set; }
        public StatusDaAprovacaoDaMatricula StatusDaAprovacao { get; private set; }
        public string Ip { get; private set; }
        public decimal? ValorPago { get; private set; }
        public bool Cancelada { get; private set; }

        public Matricula() { }

        public Matricula(CursoAberto cursoAberto, Aluno aluno, bool estaPago, decimal valorPago)
        {
            ExcecaoDeDominio.Quando(cursoAberto == null, "Curso é obrigatório");
            ExcecaoDeDominio.Quando(aluno == null, "Aluno é obrigatório");
            ExcecaoDeDominio.Quando(!cursoAberto.ContemPublicoAlvo(aluno.TipoDePublico), "Tipo de publíco alvo do Curso e do Aluno são diferentes");

            CursoAberto = cursoAberto;
            Aluno = aluno;
            EstaPago = estaPago;
            DataDeCriacao = DateTime.Now;
            if(valorPago > 0)
                ValorPago = valorPago;
        }

        public void AdicionarObservacao(string observacao)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(observacao), "Observação é obrigatório");
            Observacao = observacao;
        }

        public void AdicionarNotaDoAlunoNoCurso(float notaDoAlunoNoCurso, StatusDaAprovacaoDaMatricula status)
        {
            ExcecaoDeDominio.Quando(notaDoAlunoNoCurso < 1 || notaDoAlunoNoCurso > 10, "Nota do aluno no curso é inválido");
            ExcecaoDeDominio.Quando(status == StatusDaAprovacaoDaMatricula.Nenhum, "Status da aprovação é inválido");
            NotaDoAlunoNoCurso = notaDoAlunoNoCurso;
            StatusDaAprovacao = status;
        }

        public void AdicionarIP(string ip)
        {
            Ip = ip;
        }

        public void CancelarMatricula()
        {
            Cancelada = true;
        }
    }
}