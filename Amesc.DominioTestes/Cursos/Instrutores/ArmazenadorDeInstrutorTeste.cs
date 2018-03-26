using Amesc.Dominio.Cursos.Instrutores;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos.Instrutores
{
    [TestClass]
    public class ArmazenadorDeInstrutorTeste
    {
        private Mock<IInstrutorRepositorio> _instrutorRepositorio;
        private ArmazenadorDeInstrutor _armazenadorDeInstrutor;
        private const string Codigo = "01";
        private const string Nome = "João";
        private const string Email = "joao@email.com";

        [TestInitialize]
        public void SetUp()
        {
            _instrutorRepositorio = new Mock<IInstrutorRepositorio>();
            _armazenadorDeInstrutor = new ArmazenadorDeInstrutor(_instrutorRepositorio.Object);
        }

        [TestMethod]
        public void DeveAdicionarInstrutor()
        {
            const int idDoInstrutorNovo = 0;
            _armazenadorDeInstrutor.Armazenar(idDoInstrutorNovo, Codigo, Nome, Email);

            _instrutorRepositorio.Verify(r => r.Adicionar(It.Is<Instrutor>(
                i => i.Codigo == Codigo && i.Nome == Nome && i.Email == Email)));
        }

        [TestMethod]
        public void DeveEditarInstrutor()
        {
            const int idDoInstrutorParaEdicao = 12;
            var instrutorParaEdicao = FluentBuilder<Instrutor>.New().Build();
            _instrutorRepositorio.Setup(r => r.ObterPorId(idDoInstrutorParaEdicao)).Returns(instrutorParaEdicao);

            _armazenadorDeInstrutor.Armazenar(idDoInstrutorParaEdicao, Codigo, Nome, Email);

            Assert.AreEqual(Nome, instrutorParaEdicao.Nome);
        }

        [TestMethod]
        public void DeveLancarExcecaoQuandoInstrutorParaEdicaoNaoForEncontrado()
        {
            const int idDoInstrutorParaEdicao = 12;

            Assert.ThrowsException<ExcecaoDeDominio>(() =>
                _armazenadorDeInstrutor.Armazenar(idDoInstrutorParaEdicao, Codigo, Nome, Email));
        }

        [TestMethod]
        public void NaoDeveAdicionarInstrutorQuandoForEdicao()
        {
            const int idDoInstrutorParaEdicao = 12;
            var instrutorParaEdicao = FluentBuilder<Instrutor>.New().Build();
            _instrutorRepositorio.Setup(r => r.ObterPorId(idDoInstrutorParaEdicao)).Returns(instrutorParaEdicao);

            _armazenadorDeInstrutor.Armazenar(idDoInstrutorParaEdicao, Codigo, Nome, Email);

            _instrutorRepositorio.Verify(r => r.Adicionar(It.IsAny<Instrutor>()), Times.Never);
        }
    }
}
