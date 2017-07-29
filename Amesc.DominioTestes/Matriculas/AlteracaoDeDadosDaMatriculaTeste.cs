using Amesc.Dominio;
using Amesc.Dominio.Matriculas;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Matriculas
{
    [TestClass]
    public class AlteracaoDeDadosDaMatriculaTeste
    {
        private Mock<IRepositorio<Matricula>> _matriculaRepositorio;
        private string _observacao;
        private float? _notaDoAlunoNoCurso;
        private Matricula _matricula;
        private int _idMatricula;
        private AlteracaoDeDadosDaMatricula _alteracaoDeDadosDaMatricula;

        [TestInitialize]
        public void Setup()
        {
            _idMatricula = 100;
            _matricula = FluentBuilder<Matricula>.New().Build();
            _matriculaRepositorio = new Mock<IRepositorio<Matricula>>();
            _matriculaRepositorio.Setup(r => r.ObterPorId(_idMatricula)).Returns(_matricula);
            _alteracaoDeDadosDaMatricula = new AlteracaoDeDadosDaMatricula(_matriculaRepositorio.Object);
        }

        [TestMethod]
        public void DeveExistirUmaMatriculaValida()
        {
            const int idMatriculaInvalida = 999;

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() =>
                _alteracaoDeDadosDaMatricula.Alterar(idMatriculaInvalida, _observacao, _notaDoAlunoNoCurso))
                .Message;
            Assert.AreEqual("Matricula não encontrada", message);
        }

        [TestMethod]
        public void DeveAlterarObservacaoQuandoExistirInformacao()
        {
            _observacao = "Observação";

            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, _observacao, _notaDoAlunoNoCurso);

            Assert.AreEqual(_observacao, _matricula.Observacao);
        }

        [TestMethod]
        public void NaoDeveAlterarObservacaoQuandoNaoExistirInformacao()
        {
            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, null, _notaDoAlunoNoCurso);
        }

        [TestMethod]
        public void DeveAlterarNotaDoAlunoNoCursoQuandoExistirInformacao()
        {
            _notaDoAlunoNoCurso = 7;

            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, null, _notaDoAlunoNoCurso);

            Assert.AreEqual(_notaDoAlunoNoCurso, _matricula.NotaDoAlunoNoCurso);
        }

        [TestMethod]
        public void NaoDeveAlterarNotaDoAlunoNoCursoQuandoNaoExistirInformacao()
        {
            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, null, null);
        }
    }
}
