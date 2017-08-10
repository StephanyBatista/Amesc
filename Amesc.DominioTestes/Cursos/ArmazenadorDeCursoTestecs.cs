using System.Collections.Generic;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class ArmazenadorDeCursoTestecs
    {
        private string _nome;
        private string _descricao;
        private string _precoSugerido;
        private string _requisitos;
        private int _periodoValidoEmAno;
        private List<string> _publicosSugeridos;
        private ArmazenadorDeCurso _armazenador;
        private Mock<IRepositorio<Curso>> _cursoRepositorio;
        private string _codigo;

        [TestInitialize]
        public void Setup()
        {
            _codigo = "ADF";
            _nome = "Curso A";
            _descricao = "Descricao A";
            _precoSugerido = "1000";
            _publicosSugeridos = new List<string> { "Médico(a)" };
            _requisitos = "Deve fazer";
            _periodoValidoEmAno = 1;
            _cursoRepositorio = new Mock<IRepositorio<Curso>>();
            _armazenador = new ArmazenadorDeCurso(_cursoRepositorio.Object);
        }

        [TestMethod]
        public void DeveCriarNovoCurso()
        {
            _armazenador.Armazenar(_codigo, 0, _nome, _descricao, _precoSugerido, _publicosSugeridos, _requisitos, _periodoValidoEmAno);

            _cursoRepositorio.Verify(r => r.Adicionar(It.IsAny<Curso>()));
        }

        [TestMethod]
        public void DeveAtualizarCurso()
        {
            const int idCurso = 1;
            _cursoRepositorio.Setup(r => r.ObterPorId(idCurso)).Returns(
                FluentBuilder<Curso>.New().Build());

            _armazenador.Armazenar(_codigo, idCurso, _nome, _descricao, _precoSugerido, _publicosSugeridos, _requisitos, _periodoValidoEmAno);

            _cursoRepositorio.Verify(r => r.Adicionar(It.IsAny<Curso>()), Times.Never);
        }

        [TestMethod]
        public void NaoDeveArmazenarQuandoPrecoSugeridoEstaInvalido()
        {
            const int idCurso = 1;

            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _armazenador.Armazenar(
                    _codigo, idCurso, _nome, _descricao, "PREÇO INVÁLIDO", _publicosSugeridos, _requisitos, _periodoValidoEmAno))
                .Message;

            Assert.AreEqual("Preço sugerido é inválido", message);
        }
    }
}
