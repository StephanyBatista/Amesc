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
        public string Observacao { get; set; }
        public float? NotaDoAlunoNoCurso { get; set; }

        public GerenciarMatriculaViewModel() { }

        public GerenciarMatriculaViewModel(Matricula entidade)
        {
            Id = entidade.Id;
            Aluno = entidade.Aluno.Nome;
            Curso = entidade.CursoAberto.Curso.Nome;
            DataDoCurso = entidade.CursoAberto.InicioDoCurso.ToString("dd/MM/yyyy");
            EstaPago = entidade.EstaPago;
            NotaDoAlunoNoCurso = entidade.NotaDoAlunoNoCurso;
            Observacao = entidade.Observacao;
        }
    }
}