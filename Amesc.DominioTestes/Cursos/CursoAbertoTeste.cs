using System;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class CursoAbertoTeste
    {
        private Curso _curso;
        private decimal _preco;
        private DateTime _dataDeAbertura;
        private DateTime _dataDeFechamento;
        private DateTime _dataDoCurso;
        private CursoAberto _cursoAberto;
        private TipoDeCursoAberto _tipoDeCursoAberto;

        [TestInitialize]
        public void Setup()
        {
            _tipoDeCursoAberto = TipoDeCursoAberto.Publico;
            _curso = FluentBuilder<Curso>.New().Build();
            _preco = 1000m;
            _dataDeAbertura = DateTime.Now.AddDays(-1);
            _dataDeFechamento = DateTime.Now;
            _dataDoCurso = DateTime.Now.AddDays(+1);
            _cursoAberto = FluentBuilder<CursoAberto>.New().Build();
        }

        [TestMethod]
        public void DeveCriarMatriculaAberta()
        {
            var cursoAberto = new CursoAberto(_curso, _preco, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, _dataDoCurso);

            Assert.AreEqual(_curso, cursoAberto.Curso);
            Assert.AreEqual(_preco, cursoAberto.Preco);
            Assert.AreEqual(_dataDeAbertura, cursoAberto.DataDeAbertura);
            Assert.AreEqual(_dataDeFechamento, cursoAberto.DataDeFechamento);
            Assert.AreEqual(_dataDoCurso, cursoAberto.DataDoCurso);
            Assert.AreEqual(_tipoDeCursoAberto, cursoAberto.Tipo);
        }

        [TestMethod]
        public void DeveEditarMatriculaAberta()
        {
            var matriculaAberta = FluentBuilder<CursoAberto>.New().Build();

            matriculaAberta.Editar(_curso, _preco, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, _dataDoCurso);

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
                () => new CursoAberto(null, _preco, TipoDeCursoAberto.Publico, _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaSemCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(null, _preco, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaSemPreco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_curso, 0, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Preço do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaSemPreco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_curso, 0, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Preço do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaSemDataDeAbertura()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_curso, _preco, _tipoDeCursoAberto, DateTime.MinValue, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Data de abertura inválida", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaSemDataDeAbertura()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_curso, _preco, _tipoDeCursoAberto, DateTime.MinValue, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Data de abertura inválida", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaDataDeAberturaMaiorQueDataFechamento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_curso, _preco, _tipoDeCursoAberto, DateTime.Now.AddDays(+5), DateTime.Now, _dataDoCurso))
                .Message;

            Assert.AreEqual("Data de abertura maior que data de fechamento", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaDataDeAberturaMaiorQueDataFechamento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_curso, _preco, _tipoDeCursoAberto, DateTime.Now.AddDays(+5), DateTime.Now, _dataDoCurso))
                .Message;

            Assert.AreEqual("Data de abertura maior que data de fechamento", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaSemDataDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_curso, _preco, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, DateTime.MinValue))
                .Message;

            Assert.AreEqual("Data do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaSemDataDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_curso, _preco, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, DateTime.MinValue))
                .Message;

            Assert.AreEqual("Data do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaAbertaComDataDoCursoMenorQueDataDeFechamento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_curso, _preco, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, DateTime.Now.AddDays(-3)))
                .Message;

            Assert.AreEqual("Data do curso menor que data de fechamento", message);
        }

        [TestMethod]
        public void NaoDeveEditarMatriculaAbertaComDataDoCursoMenorQueDataDeFechamento()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_curso, _preco, _tipoDeCursoAberto, _dataDeAbertura, _dataDeFechamento, DateTime.Now.AddDays(-3)))
                .Message;

            Assert.AreEqual("Data do curso menor que data de fechamento", message);
        }
    }
}
