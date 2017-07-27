using System.ComponentModel.DataAnnotations;

namespace Amesc.WebApp.ViewModels
{
    public class AlunoParaCadastroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string Cpf { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Tipo de publico é obrigatório")]
        public string TipoDePublico { get; set; }
    }
}