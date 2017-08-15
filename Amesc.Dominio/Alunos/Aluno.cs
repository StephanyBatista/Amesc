using System;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Alunos
{
    public class Aluno : Entidade
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

        public Aluno() { }

        public Aluno(string nome, string cpf, string orgaoEmissorDoRg, string rg, DateTime dataDeNascimento, string registroProfissional, string telefone, Endereco endereco, string tipoDePublico, string midiaSocial)
        {
            Validar(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, telefone, endereco, tipoDePublico);
            Atribuir(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, registroProfissional, telefone, endereco, tipoDePublico, midiaSocial);
        }

        public void Editar(string nome, string cpf, string orgaoEmissorDoRg, string rg, DateTime dataDeNascimento, string registroProfissional, string telefone, Endereco endereco, string tipoDePublico, string midiaSocial)
        {
            Validar(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, telefone, endereco, tipoDePublico);
            Atribuir(nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, registroProfissional, telefone, endereco, tipoDePublico, midiaSocial);
        }

        private static void Validar(string nome, string cpf, string orgaoEmissorDoRg, string rg, DateTime dataDeNascimento, string telefone, Endereco endereco, string tipoDePublico)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(cpf), "CPF é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(orgaoEmissorDoRg), "Orgão emissor do RG é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(rg), "RG é obrigatório");
            ExcecaoDeDominio.Quando(dataDeNascimento == DateTime.MinValue, "Data de nascimento é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(telefone), "Telefone é obrigatório");
            ExcecaoDeDominio.Quando(endereco == null, "Endereço é obrigatório");
            ExcecaoDeDominio.Quando(tipoDePublico == null, "Tipo de publico é obrigatório");
        }

        private void Atribuir(string nome, string cpf, string orgaoEmissorDoRg, string rg, DateTime dataDeNascimento, string registroProfissional, string telefone, Endereco endereco, string tipoDePublico, string midiaSocial)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;
            TipoDePublico = tipoDePublico;
            OrgaoEmissorDoRg = orgaoEmissorDoRg;
            Rg = rg;
            DataDeNascimento = dataDeNascimento;
            RegistroProfissional = registroProfissional;
            MidiaSocial = midiaSocial;
        }
    }
}