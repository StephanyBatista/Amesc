using System;
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
        public string Logradouro { get; set; }
        [Required(ErrorMessage = "CEP é obrigatório")]
        public string Cep { get; set; }
        [Required(ErrorMessage = "Bairro é obrigatório")]
        public string Bairro { get; set; }
        public string Complemento { get; set; }
        [Required(ErrorMessage = "Cidade é obrigatório")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "Estado é obrigatório")]
        public string Estado { get; set; }
        [Required(ErrorMessage = "Tipo de publico é obrigatório")]
        public string TipoDePublico { get; set; }
        [Required(ErrorMessage = "Orgão emissor do RG é obrigatório")]
        public string OrgaoEmissorDoRg { get; set; }
        [Required(ErrorMessage = "RG é obrigatório")]
        public string Rg { get; set; }
        [Required(ErrorMessage = "Data de nascimento é obrigatório")]
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