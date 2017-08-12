using Amesc.Dominio.Cursos;

namespace Amesc.WebApp.ViewModels
{
    public class CursoAbertoParaListaViewModel
    {
        public int Id { get; set; }
        public string PeriodoInicialParaMatricula { get; set; }
        public string PeriodoFinalParaMatricula { get; set; }
        public string InicioDoCurso { get; set; }
        public string FimDoCurso { get; set; }

        public CursoAbertoParaListaViewModel() { }

        public CursoAbertoParaListaViewModel(CursoAberto entidade)
        {
            Id = entidade.Id;
            PeriodoInicialParaMatricula = entidade.PeriodoInicialParaMatricula.HasValue ? entidade.PeriodoInicialParaMatricula.Value.ToString("dd/MM/yyyy"): string.Empty;
            PeriodoFinalParaMatricula = entidade.PeriodoFinalParaMatricula.HasValue ? entidade.PeriodoFinalParaMatricula.Value.ToString("dd/MM/yyyy"): string.Empty;
            InicioDoCurso = entidade.InicioDoCurso.ToString("dd/MM/yyyy");
            FimDoCurso = entidade.FimDoCurso.ToString("dd/MM/yyyy");
        }
    }
}