using System;
using Amesc.Dominio.Pessoas;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Pessoas
{
    [TestClass]
    public class PessoaTeste
    {
        private string _nome;
        private string _cpf;
        private string _tipoDePublico;
        private Pessoa _pessoa;
        private string _telefone;
        private Endereco _endereco;
        private string _orgaoEmissorDoRg;
        private string _rg;
        private string _registroProfissional;
        private DateTime _dataDeNascimento;
        private string _midiaSocial;
        private string _especialidade;
        private TipoDePessoa _tipoDePessoa;

        [TestInitialize]
        public void Setup()
        {
            _nome = "Aluno";
            _cpf = "001";
            _telefone = "01";
            _tipoDePublico = "Médico(a)";
            _especialidade = "Pediatra";
            _orgaoEmissorDoRg = "MS";
            _rg = "001336781";
            _registroProfissional = "aaxx";
            _dataDeNascimento = DateTime.Now;
            _midiaSocial = "facebook";
            _endereco = FluentBuilder<Endereco>.New().Build();
            _pessoa = FluentBuilder<Pessoa>.New().Build();
            _tipoDePessoa = TipoDePessoa.Aluno;
        }

        private Pessoa CriarPessoa(){
            return new Pessoa(
                _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                _tipoDePublico, _especialidade, _midiaSocial, _tipoDePessoa);
        }

        private Pessoa EditarPessoa(){
            var pessoa = FluentBuilder<Pessoa>.New().Build();

            pessoa.Editar(
                _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, 
                _endereco, _tipoDePublico, _especialidade, _midiaSocial);

            return pessoa;
        }

        [TestMethod]
        public void DeveCriarAluno()
        {
            var pessoa = CriarPessoa();

            Assert.AreEqual(_nome, pessoa.Nome);
            Assert.AreEqual(_cpf, pessoa.Cpf);
            Assert.AreEqual(_orgaoEmissorDoRg, pessoa.OrgaoEmissorDoRg);
            Assert.AreEqual(_rg, pessoa.Rg);
            Assert.AreEqual(_dataDeNascimento, pessoa.DataDeNascimento);
            Assert.AreEqual(_registroProfissional, pessoa.RegistroProfissional);
            Assert.AreEqual(_telefone, pessoa.Telefone);
            Assert.AreEqual(_endereco, pessoa.Endereco);
            Assert.AreEqual(_tipoDePublico, pessoa.TipoDePublico);
            Assert.AreEqual(_midiaSocial, pessoa.MidiaSocial);
            Assert.AreEqual(_especialidade, pessoa.Especialidade);
            Assert.AreEqual(_tipoDePessoa, pessoa.TipoDePessoa);
        }

        [TestMethod]
        public void DeveNomeDaPessoaFicarNoMaiusculo()
        {
            var pessoa = CriarPessoa();

            Assert.Equals(_nome.ToUpper(), pessoa.Nome);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemNome()
        {
            _nome = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => CriarPessoa())
                .Message;

            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemCpf()
        {
            _cpf = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => CriarPessoa())
                .Message;

            Assert.AreEqual("CPF é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemOrgaoEmissorDoRg()
        {
            _orgaoEmissorDoRg = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => CriarPessoa())
                .Message;

            Assert.AreEqual("Orgão emissor do RG é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemRg()
        {
            _rg = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => CriarPessoa())
                .Message;

            Assert.AreEqual("RG é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemDataDeNascimento()
        {
            _dataDeNascimento = DateTime.MinValue;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => CriarPessoa())
                .Message;

            Assert.AreEqual("Data de nascimento é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemTelefone()
        {
            _telefone = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => CriarPessoa())
                .Message;

            Assert.AreEqual("Telefone é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemEndereco()
        {
            _endereco = null;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => CriarPessoa())
                .Message;

            Assert.AreEqual("Endereço é obrigatório", message);
        }

        [TestMethod]
        public void DeveEditarPessoa()
        {
            var pessoa = EditarPessoa();

            Assert.AreEqual(_nome, pessoa.Nome);
            Assert.AreEqual(_cpf, pessoa.Cpf);
            Assert.AreEqual(_orgaoEmissorDoRg, pessoa.OrgaoEmissorDoRg);
            Assert.AreEqual(_rg, pessoa.Rg);
            Assert.AreEqual(_dataDeNascimento, pessoa.DataDeNascimento);
            Assert.AreEqual(_registroProfissional, pessoa.RegistroProfissional);
            Assert.AreEqual(_telefone, pessoa.Telefone);
            Assert.AreEqual(_endereco, pessoa.Endereco);
            Assert.AreEqual(_tipoDePublico, pessoa.TipoDePublico);
            Assert.AreEqual(_midiaSocial, pessoa.MidiaSocial);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemNome()
        {
            _nome = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => EditarPessoa())
                .Message;

            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemCpf()
        {
            _cpf = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => EditarPessoa())
                .Message;

            Assert.AreEqual("CPF é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemOrgaoEmissorDoRg()
        {
            _orgaoEmissorDoRg = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => EditarPessoa())
                .Message;

            Assert.AreEqual("Orgão emissor do RG é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemRg()
        {
            _rg = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => EditarPessoa())
                .Message;

            Assert.AreEqual("RG é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemDataDeNascimento()
        {
            _dataDeNascimento = DateTime.MinValue;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => EditarPessoa())
                .Message;

            Assert.AreEqual("Data de nascimento é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemTelefone()
        {
            _telefone = string.Empty;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => EditarPessoa())
                .Message;

            Assert.AreEqual("Telefone é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemEndereco()
        {
            _endereco = null;
            
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => EditarPessoa())
                .Message;

            Assert.AreEqual("Endereço é obrigatório", message);
        }
    }
}
