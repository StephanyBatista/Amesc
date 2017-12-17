using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Moq;
using System;
using Nosbor.FluentBuilder.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class ArmazenadorDeCursoAbertoTeste
    {
        private string _preco;
        private DateTime _dataDeAbertura;
        private DateTime _dataDeFechamento;
        private DateTime _dataDeInicioDoCurso;
        private int _idCurso;
        private Mock<IRepositorio<Curso>> _cursoRepositorio;
        private Mock<IRepositorio<CursoAberto>> _cursoAbertoRepositorio;
        private ArmazenadorDeCursoAberto _armazenador;
        private string _tipoDeCursoEmString;
        private DateTime _dataDeFimDoCurso;
        private string _codigoDoCurso;

        [TestInitialize]
        public void Setup()
        {
            _preco = "10";
            _codigoDoCurso = "XPTO";
            _idCurso = 10;
            _dataDeAbertura = DateTime.Now.AddDays(-10);
            _dataDeFechamento = DateTime.Now.AddDays(-1);
            _dataDeInicioDoCurso = DateTime.Now;
            _dataDeFimDoCurso = DateTime.Now.AddDays(10);
            _tipoDeCursoEmString = "Fechado";

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
            _armazenador.Armazenar(id, _codigoDoCurso, _idCurso, _preco, _tipoDeCursoEmString, null, _dataDeAbertura, _dataDeFechamento, _dataDeInicioDoCurso, _dataDeFimDoCurso);

            _cursoAbertoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<CursoAberto>()));
        }

        [TestMethod]
        public void DeveEditarCursoAberto()
        {
            const int id = 1;
            _cursoAbertoRepositorio.Setup(repositorio => repositorio.ObterPorId(id))
                .Returns(FluentBuilder<CursoAberto>.New().Build());

            _armazenador.Armazenar(id, _codigoDoCurso, _idCurso, _preco, _tipoDeCursoEmString, null, _dataDeAbertura, _dataDeFechamento, _dataDeInicioDoCurso, _dataDeFimDoCurso);

            _cursoAbertoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<CursoAberto>()), Times.Never);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoPrecoNulo()
        {
            const int id = 0;
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _armazenador.Armazenar(id, _codigoDoCurso, _idCurso, null, _tipoDeCursoEmString, null, _dataDeAbertura, _dataDeFechamento, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Preço inválido", message);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoPrecoInvalido()
        {
            const int id = 0;
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _armazenador.Armazenar(id, _codigoDoCurso, _idCurso, "PREÇO INVÁLIDO", _tipoDeCursoEmString, null, _dataDeAbertura, _dataDeFechamento, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Preço inválido", message);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoTipoInvalido()
        {
            const int id = 0;
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() =>
                    _armazenador.Armazenar(id, _codigoDoCurso, _idCurso, _preco, "ENUM INVÁLIDO", null, _dataDeAbertura, _dataDeFechamento, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Tipo de curso inválido", message);
        }
    }
}
