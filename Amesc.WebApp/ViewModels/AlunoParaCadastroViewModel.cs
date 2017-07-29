using System.ComponentModel.DataAnnotations;
using Amesc.Dominio.Alunos;

namespace Amesc.WebApp.ViewModels
{
    public class AlunoParaCadastroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF é obrigatório")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Telefone é obrigatório")]
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        [Required(ErrorMessage = "Tipo de publico é obrigatório")]
        public string TipoDePublico { get; set; }

        public AlunoParaCadastroViewModel() { }

        public AlunoParaCadastroViewModel(Aluno entidade)
        {
            Id = entidade.Id;
            Nome = entidade.Nome;
            Cpf = entidade.Cpf;
            TipoDePublico = entidade.TipoDePublico;
            if (entidade.Contato == null) return;
            if(!string.IsNullOrEmpty(entidade.Contato.Telefone))
                Telefone = entidade.Contato.Telefone;
            if (!string.IsNullOrEmpty(entidade.Contato.Endereco))
                Endereco = entidade.Contato.Endereco;
        }
    }
}