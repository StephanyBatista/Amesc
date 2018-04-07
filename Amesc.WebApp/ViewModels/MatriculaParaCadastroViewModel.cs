using System.Collections.Generic;
using Amesc.Dominio.Cursos.Instrutores;

namespace Amesc.WebApp.ViewModels
{
    public class MatriculaParaCadastroViewModel
    {
        public int IdCursoAberto { get; set; }
        public int IdAluno { get; set; }
        public bool EstaPago { get; set; }
        public string ValorPago { get; set; }
        public IEnumerable<PessoaParaCadastroViewModel> Alunos { get; set; }
        public IEnumerable<CursoAbertoParaCadastroViewModel> CursosAbertos { get; set; }
    }
}