using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Moq;
using System;
using Amesc.Dominio.Cursos.Instrutores;
using Nosbor.FluentBuilder.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class ArmazenadorDeCursoAbertoTeste
    {
        private Mock<IRepositorio<Curso>> _cursoRepositorio;
        private Mock<IRepositorio<CursoAberto>> _cursoAbertoRepositorio;
        private ArmazenadorDeCursoAberto _armazenador;
        private CursoAbertoParaCadastroViewModel _dto;

        [TestInitialize]
        public void Setup()
        {
            _dto = new CursoAbertoParaCadastroViewModel
            {
                Preco = "10",
                Codigo = "XPTO",
                IdCurso = 10,
                PeriodoFinalParaMatricula = DateTime.Now.AddDays(-1),
                PeriodoInicialParaMatricula = DateTime.Now.AddDays(-10),
                InicioDoCurso = DateTime.Now,
                FimDoCurso = DateTime.Now.AddDays(10),
                TipoDeCursoAberto = "Publico"
            };

            _cursoRepositorio = new Mock<IRepositorio<Curso>>();
            _cursoRepositorio.Setup(repositorio => repositorio.ObterPorId(_dto.IdCurso))
                .Returns(FluentBuilder<Curso>.New().Build);
            _cursoAbertoRepositorio = new Mock<IRepositorio<CursoAberto>>();
            _armazenador = new ArmazenadorDeCursoAberto(_cursoRepositorio.Object, _cursoAbertoRepositorio.Object);
        }

        [TestMethod]
        public void DeveSalvarCursoAberto()
        {
            _dto.Id = 0;
            _armazenador.Armazenar(_dto);

            _cursoAbertoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<CursoAberto>()));
        }

        [TestMethod]
        public void DeveEditarCursoAberto()
        {
            _dto.Id = 7;
            _cursoAbertoRepositorio.Setup(repositorio => repositorio.ObterPorId(_dto.Id))
                .Returns(FluentBuilder<CursoAberto>.New().Build());

            _armazenador.Armazenar(_dto);

            _cursoAbertoRepositorio.Verify(repositorio => 
                repositorio.Adicionar(It.IsAny<CursoAberto>()), Times.Never);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoPrecoNulo()
        {
            _dto.Id = 0;
            _dto.Preco = null;
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _armazenador.Armazenar(_dto))
                .Message;

            Assert.AreEqual("Preço inválido", message);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoPrecoInvalido()
        {
            _dto.Id = 0;
            _dto.Preco = "PREÇO INVÁLIDO";
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _armazenador.Armazenar(_dto))
                .Message;

            Assert.AreEqual("Preço inválido", message);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoTipoInvalido()
        {
            _dto.Id = 0;
            _dto.TipoDeCursoAberto = "ENUM INVÁLIDO";
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() =>
                    _armazenador.Armazenar(_dto))
                .Message;

            Assert.AreEqual("Tipo de curso inválido", message);
        }
    }
}
