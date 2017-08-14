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

        [TestInitialize]
        public void Setup()
        {
            _nome = "Aluno";
            _cpf = "001";
            _telefone = "01";
            _tipoDePublico = "Médico(a)";
            _endereco = FluentBuilder<Endereco>.New().Build();
            _aluno = FluentBuilder<Aluno>.New().Build();
        }

        [TestMethod]
        public void DeveCriarAluno()
        {
            var aluno = new Aluno(_nome, _cpf, _telefone, _endereco, _tipoDePublico);

            Assert.AreEqual(_nome, aluno.Nome);
            Assert.AreEqual(_cpf, aluno.Cpf);
            Assert.AreEqual(_telefone, aluno.Telefone);
            Assert.AreEqual(_endereco, aluno.Endereco);
            Assert.AreEqual(_tipoDePublico, aluno.TipoDePublico);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemNome()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new Aluno(null, _cpf, _telefone, _endereco, _tipoDePublico))
                .Message;

            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemCpf()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _aluno.Editar(_nome, null, _telefone, _endereco, _tipoDePublico))
                .Message;

            Assert.AreEqual("CPF é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemTelefone()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _aluno.Editar(_nome, _cpf, null, _endereco, _tipoDePublico))
                .Message;

            Assert.AreEqual("Telefone é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemEndereco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _aluno.Editar(_nome, _cpf, _telefone, null, _tipoDePublico))
                .Message;

            Assert.AreEqual("Endereço é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarAlunoSemTipoDePublico()
        {
            var message  = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _aluno.Editar(_nome, _cpf, _telefone, _endereco, null))
                .Message;

            Assert.AreEqual("Tipo de publico é obrigatório", message);
        }

        [TestMethod]
        public void DeveEditarAluno()
        {
            var aluno = FluentBuilder<Aluno>.New().Build();

            aluno.Editar(_nome, _cpf, _telefone, _endereco, _tipoDePublico);

            Assert.AreEqual(_nome, aluno.Nome);
            Assert.AreEqual(_cpf, aluno.Cpf);
            Assert.AreEqual(_telefone, aluno.Telefone);
            Assert.AreEqual(_endereco, aluno.Endereco);
            Assert.AreEqual(_tipoDePublico, aluno.TipoDePublico);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemNome()
        {
            var message  = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new Aluno(null, _cpf, _telefone, _endereco, _tipoDePublico))
                .Message;

            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemCpf()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new Aluno(_nome, null, _telefone, _endereco, _tipoDePublico))
                .Message;

            Assert.AreEqual("CPF é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemTelefone()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new Aluno(_nome, _cpf, null, _endereco, _tipoDePublico))
                .Message;

            Assert.AreEqual("Telefone é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemEndereco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new Aluno(_nome, _cpf, _telefone, null, _tipoDePublico))
                .Message;

            Assert.AreEqual("Endereço é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarAlunoSemTipoDePublico()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new Aluno(_nome, _cpf, _telefone, _endereco, null))
                .Message;

            Assert.AreEqual("Tipo de publico é obrigatório", message);
        }
    }
}
