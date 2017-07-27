using System;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class CursoComMatriculasAbertaTeste
    {
        private Curso _curso;
        private decimal _preco;
        private DateTime _dataDeAbertura;
        private DateTime _dataDeFechamento;
        private DateTime _dataDoCurso;
        private CursoComMatriculaAberta _cursoComMatriculaAberta;

        [TestInitialize]
        public void Setup()
        {
            _curso = FluentBuilder<Curso>.New().Build();
            _preco = 1000m;
            _dataDeAbertura = DateTime.Now.AddDays(-1);
            _dataDeFechamento = DateTime.Now;
            _dataDoCurso = DateTime.Now.AddDays(+1);
            _cursoComMatriculaAberta = FluentBuilder<CursoComMatriculaAberta>.New().Build();
        }

        [TestMethod]
        public void DeveCriarMatriculaAberta()
        {
            var matriculaAberta = new CursoComMatriculaAberta(_curso, _preco, _dataDeAbertura, _dataDeFechamento, _dataDoCurso);

            Assert.AreEqual(_curso, matriculaAberta.Curso);
            Assert.AreEqual(_preco, matriculaAberta.Preco);
            Assert.AreEqual(_dataDeAbertura, matriculaAberta.DataDeAbertura);
            Assert.AreEqual(_dataDeFechamento, matriculaAberta.DataDeFechamento);
            Assert.AreEqual(_dataDoCurso, matriculaAberta.DataDoCurso);
        }

        [TestMethod]
        public void DeveEditarMatriculaAberta()
        {
            var matriculaAberta = FluentBuilder<CursoComMatriculaAberta>.New().Build();

            matriculaAberta.Editar(_curso, _preco, _dataDeAbertura, _dataDeFechamento, _dataDoCurso);

            Assert.AreEqual(_curso, matriculaAberta.Curso);
            Assert.AreEqual(_preco, matriculaAberta.Preco);
            Assert.AreEqual(_dataDeAbertura, matriculaAberta.DataDeAbertura);
            Assert.AreEqual(_dataDeFechamento, matriculaAberta.DataDeFechamento);
            Assert.AreEqual(_dataDoCurso, matriculaAberta.DataDoCurso);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaSemCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoComMatriculaAberta(null, _preco, _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaSemCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoComMatriculaAberta.Editar(null, _preco, _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaSemPreco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoComMatriculaAberta(_curso, 0, _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Preço do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaSemPreco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoComMatriculaAberta.Editar(_curso, 0, _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Preço do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaSemDataDeAbertura()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoComMatriculaAberta(_curso, _preco, DateTime.MinValue, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Data de abertura inválida", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaSemDataDeAbertura()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoComMatriculaAberta.Editar(_curso, _preco, DateTime.MinValue, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Data de abertura inválida", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaDataDeAberturaMaiorQueDataFechamento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoComMatriculaAberta(_curso, _preco, DateTime.Now.AddDays(+5), DateTime.Now, _dataDoCurso))
                .Message;

            Assert.AreEqual("Data de abertura maior que data de fechamento", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaDataDeAberturaMaiorQueDataFechamento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoComMatriculaAberta.Editar(_curso, _preco, DateTime.Now.AddDays(+5), DateTime.Now, _dataDoCurso))
                .Message;

            Assert.AreEqual("Data de abertura maior que data de fechamento", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaSemDataDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoComMatriculaAberta(_curso, _preco, _dataDeAbertura, _dataDeFechamento, DateTime.MinValue))
                .Message;

            Assert.AreEqual("Data do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaSemDataDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoComMatriculaAberta.Editar(_curso, _preco, _dataDeAbertura, _dataDeFechamento, DateTime.MinValue))
                .Message;

            Assert.AreEqual("Data do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaComDataDoCursoMenorQueDataDeFechamento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoComMatriculaAberta(_curso, _preco, _dataDeAbertura, _dataDeFechamento, DateTime.Now.AddDays(-3)))
                .Message;

            Assert.AreEqual("Data do curso menor que data de fechamento", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaComDataDoCursoMenorQueDataDeFechamento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoComMatriculaAberta.Editar(_curso, _preco, _dataDeAbertura, _dataDeFechamento, DateTime.Now.AddDays(-3)))
                .Message;

            Assert.AreEqual("Data do curso menor que data de fechamento", message);
        }
    }
}
