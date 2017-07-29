using System;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class ArmazenadorDeCursoAbertoTeste
    {
        private string _preco;
        private DateTime _dataDeAbertura;
        private DateTime _dataDeFechamento;
        private DateTime _dataDoCurso;
        private int _idCurso;
        private Mock<IRepositorio<Curso>> _cursoRepositorio;
        private Mock<IRepositorio<CursoAberto>> _cursoAbertoRepositorio;
        private ArmazenadorDeCursoAberto _armazenador;

        [TestInitialize]
        public void Setup()
        {
            _preco = "10";
            _idCurso = 10;
            _dataDeAbertura = DateTime.Now.AddDays(-10);
            _dataDeFechamento = DateTime.Now.AddDays(-1);
            _dataDoCurso = DateTime.Now;

            _cursoRepositorio = new Mock<IRepositorio<Curso>>();
            _cursoRepositorio.Setup(repositorio => repositorio.ObterPorId(_idCurso))
                .Returns(FluentBuilder<Curso>.New().Build);
            _cursoAbertoRepositorio = new Mock<IRepositorio<CursoAberto>>();
            _armazenador = new ArmazenadorDeCursoAberto(_cursoRepositorio.Object, _cursoAbertoRepositorio.Object);
        }

        [TestMethod]
        public void DeveSalvarCursoAberto()
        {
            const int id = 0;
            _armazenador.Armazenar(id, _idCurso, _preco, _dataDeAbertura, _dataDeFechamento, _dataDoCurso);

            _cursoAbertoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<CursoAberto>()));
        }

        [TestMethod]
        public void DeveEditarCursoAberto()
        {
            const int id = 1;
            _cursoAbertoRepositorio.Setup(repositorio => repositorio.ObterPorId(id))
                .Returns(FluentBuilder<CursoAberto>.New().Build());

            _armazenador.Armazenar(id, _idCurso, _preco, _dataDeAbertura, _dataDeFechamento, _dataDoCurso);

            _cursoAbertoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<CursoAberto>()), Times.Never);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoPrecoNulo()
        {
            const int id = 0;
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _armazenador.Armazenar(id, _idCurso, null,
                    _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Preço inválido", message);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoPrecoInvalido()
        {
            const int id = 0;
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => _armazenador.Armazenar(id, _idCurso, "PREÇO INVÁLIDO",
                    _dataDeAbertura, _dataDeFechamento, _dataDoCurso))
                .Message;

            Assert.AreEqual("Preço inválido", message);
        }
    }
}
