using Amesc.Dominio.Cursos.Instrutores;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos.Instrutores
{
    [TestClass]
    public class InstrutorTeste
    {
        private string _codigo = "01";
        private string _nome = "Jorge";
        private string _email = "email";

        [TestMethod]
        public void DeveCriarInstrutor()
        {
            var instrutor = new Instrutor(_codigo, _nome, _email);

            Assert.AreEqual(_codigo, instrutor.Codigo);
            Assert.AreEqual(_nome, instrutor.Nome);
            Assert.AreEqual(_email, instrutor.Email);
        }

        [TestMethod]
        public void DeveAlterarInstrutor()
        {
            _codigo = "02";
            _nome = "Maria";
            _email = "maria@marial.com.br";
            var instrutor = FluentBuilder<Instrutor>.New().Build();

            instrutor.Editar(_codigo, _nome, _email);

            Assert.AreEqual(_codigo, instrutor.Codigo);
            Assert.AreEqual(_nome, instrutor.Nome);
            Assert.AreEqual(_email, instrutor.Email);
        }

        [TestMethod]
        public void NaoDeveCriarInstrutorSemNome()
        {
            Assert.ThrowsException<ExcecaoDeDominio>(() => new Instrutor(_codigo, null, _email));
        }

        [TestMethod]
        public void NaoDeveEditarInstrutorSemNome()
        {
            var instrutor = FluentBuilder<Instrutor>.New().Build();

            Assert.ThrowsException<ExcecaoDeDominio>(() => instrutor.Editar(_codigo, null, _email));
        }
    }
}
