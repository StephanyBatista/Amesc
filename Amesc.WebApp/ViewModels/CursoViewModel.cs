using Amesc.Dominio.Cursos;

namespace Amesc.WebApp.ViewModels
{
    public class CursoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public CursoViewModel() { }

        public CursoViewModel(Curso entidade)
        {
            Id = entidade.Id;
            Nome = entidade.Nome;
        }
    }
}