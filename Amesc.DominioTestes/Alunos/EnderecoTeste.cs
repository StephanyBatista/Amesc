using Amesc.Dominio.Alunos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amesc.DominioTestes.Alunos
{
    [TestClass]
    public class EnderecoTeste
    {
        private string _telefone;
        private string _logradouro;
        private string _numero;
        private string _bairro;
        private object _complemento;
        private string _cidade;
        private string _estado;

        [TestInitialize]
        public void Setup()
        {
            _telefone = "99";
            _numero = "29";
            _logradouro = "Doutor";
            _bairro = "Mata";
            _complemento = null;
            _cidade = "Campo Grande";
            _estado = "MS";
        }

        [TestMethod]
        public void DeveCriarEndereco()
        {
            var endereco = new Endereco(_numero, _logradouro, _bairro, _complemento, _cidade, _estado);

            Assert.AreEqual(_numero, endereco.Numero);
            Assert.AreEqual(_logradouro, endereco.Logradouro);
            Assert.AreEqual(_bairro, endereco.Bairro);
            Assert.AreEqual(_complemento, endereco.Complemento);
            Assert.AreEqual(_cidade, endereco.Cidade);
            Assert.AreEqual(_estado, endereco.Estado);
        }

        [TestMethod]
        public void NaoDeveCriarEnderecoSemNumero()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Endereco(null, _logradouro, _bairro, _complemento, _cidade, _estado)).
                Message;

            Assert.AreEqual("Número do endereço é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarEnderecoSemLogradouro()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Endereco(_numero, null, _bairro, _complemento, _cidade, _estado)).
                Message;

            Assert.AreEqual("Logradouro do endereço é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarEnderecoSemBairro()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Endereco(_numero, _logradouro, null, _complemento, _cidade, _estado)).
                Message;

            Assert.AreEqual("Bairro do endereço é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarEnderecoSemCidade()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Endereco(_numero, _logradouro, _bairro, _complemento, null, _estado)).
                Message;

            Assert.AreEqual("Cidade do endereço é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarEnderecoSemEstado()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Endereco(_numero, _logradouro, _bairro, _complemento, _cidade, null)).
                Message;

            Assert.AreEqual("Estado do endereço é obrigatório", message);
        }
    }
}
