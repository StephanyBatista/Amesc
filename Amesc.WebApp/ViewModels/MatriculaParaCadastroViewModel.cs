using System.Collections.Generic;

namespace Amesc.WebApp.ViewModels
{
    public class MatriculaParaCadastroViewModel
    {
        public int IdCursoAberto { get; set; }
        public int IdAluno { get; set; }
        public bool EstaPago { get; set; }
        public IEnumerable<AlunoParaCadastroViewModel> Alunos { get; set; }
        public IEnumerable<CursoAbertoParaCadastroViewModel> CursosAbertos { get; set; }
    }
}