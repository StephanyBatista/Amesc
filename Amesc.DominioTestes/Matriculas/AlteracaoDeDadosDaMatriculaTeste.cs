﻿using Amesc.Dominio;
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
        private bool _ip;
        private int _idMatricula;
        private string _observacao;
        private string _notaDoAlunoNoCursoEmString;
        private string _statusDaAprovacao;
        private Matricula _matricula;
        private Mock<IRepositorio<Matricula>> _matriculaRepositorio;
        private AlteracaoDeDadosDaMatricula _alteracaoDeDadosDaMatricula;

        [TestInitialize]
        public void Setup()
        {
            _idMatricula = 100;
            _statusDaAprovacao = null;
            _ip = true;
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
                _alteracaoDeDadosDaMatricula.Alterar(idMatriculaInvalida, _observacao, _notaDoAlunoNoCursoEmString, _statusDaAprovacao, _ip))
                .Message.StartsWith("Matricula não encontrada");
        }

        [TestMethod]
        public void DeveAlterarObservacaoQuandoExistirInformacao()
        {
            _observacao = "Observação";

            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, _observacao, _notaDoAlunoNoCursoEmString, _statusDaAprovacao, _ip);

            Assert.AreEqual(_observacao, _matricula.Observacao);
        }

        [TestMethod]
        public void DeveInformarQueAlunoTemPotencialParaSerInstrutor()
        {
            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, _observacao, _notaDoAlunoNoCursoEmString, _statusDaAprovacao, _ip);

            Assert.AreEqual(_ip, _matricula.Ip);
        }

        [TestMethod]
        public void NaoDeveAlterarObservacaoQuandoNaoExistirInformacao()
        {
            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, null, _notaDoAlunoNoCursoEmString, _statusDaAprovacao, _ip);
        }

        [TestMethod]
        public void DeveAlterarNotaDoAlunoEStatusDaAprovacaoNoCursoQuandoExistirInformacao()
        {
            _notaDoAlunoNoCursoEmString = "7";

            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, null, _notaDoAlunoNoCursoEmString, "Reprovado", _ip);

            Assert.AreEqual(float.Parse(_notaDoAlunoNoCursoEmString), _matricula.NotaDoAlunoNoCurso);
            Assert.AreEqual(StatusDaAprovacaoDaMatricula.Reprovado, _matricula.StatusDaAprovacao);
        }

        [TestMethod]
        public void NaoDeveAlterarNotaDoAlunoNoCursoQuandoNaoExistirInformacao()
        {
            _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, null, null, _statusDaAprovacao, _ip);
        }

        [TestMethod]
        public void NaoDeveAlterarNotaDoAlunoEStatusDaAprovacaoNoCursoQuandoStatusEhInvalido()
        {
            Assert.ThrowsException<ExcecaoDeDominio>(() => _alteracaoDeDadosDaMatricula.Alterar(_idMatricula, null, "7", "STATUS_INVALIDO", _ip))
                .Message.StartsWith("Status da aprovação é inválido");
        }
    }
}
