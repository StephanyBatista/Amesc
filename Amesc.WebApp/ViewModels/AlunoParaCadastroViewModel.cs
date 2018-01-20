using System;
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
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "CEP � obrigat�rio")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Bairro � obrigat�rio")]
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Cidade � obrigat�rio")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Estado � obrigat�rio")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Tipo de publico � obrigat�rio")]
        public string TipoDePublico { get; set; }
        [Required(ErrorMessage = "Org�o emissor do RG � obrigat�rio")]
        public string OrgaoEmissorDoRg { get; set; }
        [Required(ErrorMessage = "RG � obrigat�rio")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Data de nascimento � obrigat�rio")]
        public string DataDeNascimento { get; set; }
        public string RegistroProfissional { get; set; }
        public string MidiaSocial { get; set; }
        public string Especialidade { get; set; }

        public AlunoParaCadastroViewModel() { }

        public AlunoParaCadastroViewModel(Aluno entidade)
        {
            Id = entidade.Id;
            Nome = entidade.Nome;
            Cpf = entidade.Cpf;
            OrgaoEmissorDoRg = entidade.OrgaoEmissorDoRg;
            Rg = entidade.Rg;
            DataDeNascimento = entidade.DataDeNascimento.ToString("dd/MM/yyyy");
            RegistroProfissional = entidade.RegistroProfissional;
            TipoDePublico = entidade.TipoDePublico;
            Especialidade = entidade.Especialidade;
            Telefone = entidade.Telefone;
            Numero = entidade.Endereco.Numero;
            Logradouro = entidade.Endereco.Logradouro;
            Bairro = entidade.Endereco.Bairro;
            Complemento = entidade.Endereco.Complemento;
            Cidade = entidade.Endereco.Cidade;
            Estado = entidade.Endereco.Estado;
            Cep = entidade.Endereco.Cep;
            MidiaSocial = entidade.MidiaSocial;
        }
    }
}