using System.ComponentModel.DataAnnotations;
using Amesc.Dominio.Alunos;

namespace Amesc.WebApp.ViewModels
{
    public class AlunoParaCadastroViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome � obrigat�rio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF � obrigat�rio")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Telefone � obrigat�rio")]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "N�mero � obrigat�rio")]
        public string Numero { get; set; }
        [Required(ErrorMessage = "Logradouro � obrigat�rio")]
        public string Logradouro { get; private set; }
        [Required(ErrorMessage = "Bairro � obrigat�rio")]
        public string Bairro { get; private set; }
        [Required(ErrorMessage = "Complemento � obrigat�rio")]
        public object Complemento { get; private set; }
        [Required(ErrorMessage = "Cidade � obrigat�rio")]
        public string Cidade { get; private set; }
        [Required(ErrorMessage = "Estado � obrigat�rio")]
        public string Estado { get; private set; }
        [Required(ErrorMessage = "Tipo de publico � obrigat�rio")]
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