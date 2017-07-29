using Amesc.Dominio.Cursos;

namespace Amesc.WebApp.ViewModels
{
    public class CursoAbertoParaListaViewModel
    {
        public int Id { get; set; }
        public string DataDeAbertura { get; set; }
        public string DataDeFechamento { get; set; }
        public string DataDoCurso { get; set; }

        public CursoAbertoParaListaViewModel() { }

        public CursoAbertoParaListaViewModel(CursoAberto entidade)
        {
            Id = entidade.Id;
            DataDeAbertura = entidade.DataDeAbertura.ToString("dd/MM/yyyy");
            DataDeFechamento = entidade.DataDeFechamento.ToString("dd/MM/yyyy");
            DataDoCurso = entidade.DataDoCurso.ToString("dd/MM/yyyy");
        }
    }
}