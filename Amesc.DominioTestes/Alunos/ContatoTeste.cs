using Amesc.Dominio.Alunos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amesc.DominioTestes.Alunos
{
    [TestClass]
    public class ContatoTeste
    {
        private string _telefone;
        private string _endereco;

        [TestInitialize]
        public void Setup()
        {
            _telefone = "99";
            _endereco = "77";
        }

        [TestMethod]
        public void DeveCriarContato()
        {
            var contato = new Contato(_telefone, _endereco);

            Assert.AreEqual(contato.Telefone, _telefone);
            Assert.AreEqual(contato.Endereco, _endereco);
        }

        [TestMethod]
        public void NaoDeveCriarContatoSemTelefone()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Contato(null, _endereco))
                .Message;

            Assert.AreEqual("Telefone é obrigatório", message);
        }
    }
}
