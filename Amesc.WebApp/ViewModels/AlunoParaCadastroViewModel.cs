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
        [Required(ErrorMessage = "Número é obrigatório")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Logradouro é obrigatório")]
        public string Logradouro { get; private set; }
        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; private set; }
        [Required(ErrorMessage = "Complemento é obrigatório")]
        public object Complemento { get; private set; }
        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; private set; }
        [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; private set; }
        [Required(ErrorMessage = "Tipo de publico é obrigatório")]
        public string TipoDePublico { get; set; }

        public AlunoParaCadastroViewModel() { }

        public AlunoParaCadastroViewModel(Aluno entidade)
        {
            Id = entidade.Id;
            Nome = entidade.Nome;
            Cpf = entidade.Cpf;
            TipoDePublico = entidade.TipoDePublico;
            Telefone = entidade.Telefone;
            Numero = entidade.Endereco.Numero;
            Logradouro = entidade.Endereco.Logradouro;
            Bairro = entidade.Endereco.Bairro;
            Complemento = entidade.Endereco.Complemento;
            Cidade = entidade.Endereco.Cidade;
            Estado = entidade.Endereco.Estado;
        }
    }
}