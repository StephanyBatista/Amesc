using Amesc.Dominio.Matriculas;

namespace Amesc.WebApp.ViewModels
{
    public class GerenciarMatriculaViewModel
    {
        public int Id { get; set; }
        public string Aluno { get; set; }
        public string Curso { get; set; }
        public string DataDoCurso { get; set; }
        public bool EstaPago { get; set; }
        public string ValorPago { get; set; }
        public string Observacao { get; set; }
        public float? NotaDoAlunoNoCurso { get; set; }
        public string StatusDaAprovacao { get; set; }
        public bool Ip { get; set; }
        public bool Cancelada { get; set; }

        public GerenciarMatriculaViewModel() { }

        public GerenciarMatriculaViewModel(Matricula entidade)
        {
            Id = entidade.Id;
            Aluno = entidade.Pessoa.Nome;
            Curso = entidade.CursoAberto.Curso.Nome;
            DataDoCurso = entidade.CursoAberto.InicioDoCurso.ToString("dd/MM/yyyy");
            EstaPago = entidade.EstaPago;
            ValorPago = entidade.ValorPago.ToString();
            NotaDoAlunoNoCurso = entidade.NotaDoAlunoNoCurso;
            StatusDaAprovacao = entidade.StatusDaAprovacao.ToString();
            Ip = entidade.Ip;
            Observacao = entidade.Observacao;
            Cancelada = entidade.Cancelada;
        }
    }
}