using System.ComponentModel.DataAnnotations;

namespace Amesc.WebApp.ViewModels
{
    public class AlunoParaCadastroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF � obrigat�rio")]
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Tipo de publico � obrigat�rio")]
        public string TipoDePublico { get; set; }
    }
}