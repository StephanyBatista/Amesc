using Amesc.Dominio.Matriculas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Matriculas
{
    [TestClass]
    public class CanceladorDeMatriculaTeste
    {
        private int _matriculaId;
        private Matricula _matricula;
        private Mock<IMatriculaRepositorio> _matriculaRepositorio;
        private CanceladorDeMatricula _canceladorDeMatricula;

        [TestInitialize]
        public void SetUp()
        {
            _matriculaId = 342;
            _matricula = FluentBuilder<Matricula>.New().Build();
            _matriculaRepositorio = new Mock<IMatriculaRepositorio>();
            _matriculaRepositorio.Setup(r => r.ObterPorId(_matriculaId)).Returns(_matricula);
            _canceladorDeMatricula = new CanceladorDeMatricula(_matriculaRepositorio.Object);
        }

        [TestMethod]
        public void DeveCancelarMatricula()
        {
            _canceladorDeMatricula.Cancelar(_matriculaId);

            Assert.IsTrue(_matricula.Cancelada);
        }
    }
}
