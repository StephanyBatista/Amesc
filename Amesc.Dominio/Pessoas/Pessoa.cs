using System;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Pessoas
{
    public enum TipoDePessoa
    {
        Aluno,
        Instrutor
    }

    public class Pessoa : Entidade
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Endereco Endereco { get; private set; }
        public string TipoDePublico { get; private set; }
        public string Telefone { get; private set; }
        public string OrgaoEmissorDoRg { get; private set; }
        public string Rg { get; private set; }
        public DateTime DataDeNascimento { get; private set; }
        public string RegistroProfissional { get; private set; }
        public string MidiaSocial { get; private set; }
        public string Especialidade { get; set; }
        public TipoDePessoa TipoDePessoa { get; set; }

        public Pessoa() { }

        public Pessoa(string nome, string cpf, string orgaoEmissorDoRg, string rg, DateTime dataDeNascimento,
            string registroProfissional,
            string telefone, Endereco endereco, string tipoDePublico, string especialidade, string midiaSocial,
            TipoDePessoa tipoDePessoa)
        {
            Validar(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, telefone, endereco);
            Atribuir(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, registroProfissional, telefone, endereco, tipoDePublico, especialidade, midiaSocial);
            TipoDePessoa = tipoDePessoa;
        }

        public void Editar(
            string nome, string cpf, string orgaoEmissorDoRg, string rg, DateTime dataDeNascimento, string registroProfissional, 
            string telefone, Endereco endereco, string tipoDePublico, string especialide, string midiaSocial)
        {
            Validar(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, telefone, endereco);
            Atribuir(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, registroProfissional, telefone, endereco, tipoDePublico, especialide, midiaSocial);
        }

        private static void Validar(string nome, string cpf, string orgaoEmissorDoRg, string rg, DateTime dataDeNascimento, string telefone, Endereco endereco)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(cpf), "CPF é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(orgaoEmissorDoRg), "Orgão emissor do RG é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(rg), "RG é obrigatório");
            ExcecaoDeDominio.Quando(dataDeNascimento == DateTime.MinValue, "Data de nascimento é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(telefone), "Telefone é obrigatório");
            ExcecaoDeDominio.Quando(endereco == null, "Endereço é obrigatório");
        }

        private void Atribuir(
            string nome, string cpf, string orgaoEmissorDoRg, string rg, DateTime dataDeNascimento, string registroProfissional, 
            string telefone, Endereco endereco, string tipoDePublico, string especialidade, string midiaSocial)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            TipoDePublico = tipoDePublico;
            Especialidade = especialidade;
            OrgaoEmissorDoRg = orgaoEmissorDoRg;
            Rg = rg;
            DataDeNascimento = dataDeNascimento;
            RegistroProfissional = registroProfissional;
            MidiaSocial = midiaSocial;
            AtribuirEndereco(endereco);
        }

        private void AtribuirEndereco(Endereco endereco)
        {
            if (Endereco == null)
                Endereco = endereco;
            else
            {
                Endereco.AlterarNumero(endereco.Numero);
                Endereco.AlterarLogradouro(endereco.Logradouro);
                Endereco.AlterarBairro(endereco.Bairro);
                Endereco.AlterarComplemento(endereco.Complemento);
                Endereco.AlterarCidade(endereco.Cidade);
                Endereco.AlterarEstado(endereco.Estado);
                Endereco.AlterarCep(endereco.Cep);
            }
        }
    }
}