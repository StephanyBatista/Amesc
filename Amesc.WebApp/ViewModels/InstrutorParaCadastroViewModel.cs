using System.ComponentModel.DataAnnotations;
using Amesc.Dominio.Cursos.Instrutores;

namespace Amesc.WebApp.ViewModels
{
    public class InstrutorParaCadastroViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        public string Email { get; set; }

        public InstrutorParaCadastroViewModel() { }

        public InstrutorParaCadastroViewModel(Instrutor entidade)
        {
            Id = entidade.Id;
            Codigo = entidade.Codigo;
            Nome = entidade.Nome;
            Email = entidade.Email;
        }
    }
}
