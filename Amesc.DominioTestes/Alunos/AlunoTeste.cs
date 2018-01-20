using System;
using System.Linq;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Alunos
{
    [TestClass]
    public class AlunoTeste
    {
        private string _nome;
        private string _cpf;
        private string _tipoDePublico;
        private Aluno _aluno;
        private string _telefone;
        private Endereco _endereco;
        private string _orgaoEmissorDoRg;
        private string _rg;
        private string _registroProfissional;
        private DateTime _dataDeNascimento;
        private string _midiaSocial;
        private string _especialidade;

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
            _aluno = FluentBuilder<Aluno>.New().Build();
        }

        [TestMethod]
        public void DeveCriarAluno()
        {
            var aluno = new Aluno(
                _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                _tipoDePublico, _especialidade, _midiaSocial);

            Assert.AreEqual(_nome, aluno.Nome);
            Assert.AreEqual(_cpf, aluno.Cpf);
            Assert.AreEqual(_orgaoEmissorDoRg, aluno.OrgaoEmissorDoRg);
            Assert.AreEqual(_rg, aluno.Rg);
            Assert.AreEqual(_dataDeNascimento, aluno.DataDeNascimento);
            Assert.AreEqual(_registroProfissional, aluno.RegistroProfissional);
            Assert.AreEqual(_telefone, aluno.Telefone);
            Assert.AreEqual(_endereco, aluno.Endereco);
            Assert.AreEqual(_tipoDePublico, aluno.TipoDePublico);
            Assert.AreEqual(_midiaSocial, aluno.MidiaSocial);
            Assert.AreEqual(_especialidade, aluno.Especialidade);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemNome()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new Aluno(
                        null, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemCpf()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new Aluno(
                        _nome, null, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("CPF é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemOrgaoEmissorDoRg()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new Aluno(
                        _nome, _cpf, null, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Orgão emissor do RG é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemRg()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new Aluno(
                        _nome, _cpf, _orgaoEmissorDoRg, null, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("RG é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemDataDeNascimento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new Aluno(
                        _nome, _cpf, _orgaoEmissorDoRg, _rg, DateTime.MinValue, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Data de nascimento é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemTelefone()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new Aluno(
                        _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, null, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Telefone é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemEndereco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new Aluno(
                        _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, null, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Endereço é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemTipoDePublico()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new Aluno(
                        _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        null, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Tipo de publico é obrigatório", message);
        }

        [TestMethod]
        public void DeveEditarAluno()
        {
            var aluno = FluentBuilder<Aluno>.New().Build();

            aluno.Editar(
                _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, 
                _endereco, _tipoDePublico, _especialidade, _midiaSocial);

            Assert.AreEqual(_nome, aluno.Nome);
            Assert.AreEqual(_cpf, aluno.Cpf);
            Assert.AreEqual(_orgaoEmissorDoRg, aluno.OrgaoEmissorDoRg);
            Assert.AreEqual(_rg, aluno.Rg);
            Assert.AreEqual(_dataDeNascimento, aluno.DataDeNascimento);
            Assert.AreEqual(_registroProfissional, aluno.RegistroProfissional);
            Assert.AreEqual(_telefone, aluno.Telefone);
            Assert.AreEqual(_endereco, aluno.Endereco);
            Assert.AreEqual(_tipoDePublico, aluno.TipoDePublico);
            Assert.AreEqual(_midiaSocial, aluno.MidiaSocial);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemNome()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _aluno.Editar(
                        null, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemCpf()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _aluno.Editar(
                        _nome, null, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("CPF é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemOrgaoEmissorDoRg()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _aluno.Editar(
                        _nome, _cpf, null, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Orgão emissor do RG é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemRg()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _aluno.Editar(
                        _nome, _cpf, _orgaoEmissorDoRg, null, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("RG é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemDataDeNascimento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _aluno.Editar(
                        _nome, _cpf, _orgaoEmissorDoRg, _rg, DateTime.MinValue, _registroProfissional, _telefone, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Data de nascimento é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemTelefone()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _aluno.Editar(
                        _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, null, _endereco, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Telefone é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemEndereco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _aluno.Editar(
                        _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, null, 
                        _tipoDePublico, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Endereço é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemTipoDePublico()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _aluno.Editar(
                        _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _endereco, 
                        null, _especialidade, _midiaSocial))
                .Message;

            Assert.AreEqual("Tipo de publico é obrigatório", message);
        }

        
    }
}
