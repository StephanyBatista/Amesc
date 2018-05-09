using System;
using System.Collections.Generic;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio.Matriculas;
using Amesc.Dominio.Pessoas;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Matriculas
{
    [TestClass]
    public class MatriculaTeste
    {
        private CursoAberto _cursoAberto;
        private Pessoa _pessoa;
        private bool _estaPago;
        private FluentBuilder<Curso> _curso;
        private decimal _valorPago;
        private ComoFicouSabendo _comoFicouSabendo;

        [TestInitialize]
        public void Setup()
        {
            _curso = FluentBuilder<Curso>.New().With(c => c.PublicosAlvo,
                new List<PublicoAlvoParaCurso> {new PublicoAlvoParaCurso("Medico(a)")});
            _cursoAberto = FluentBuilder<CursoAberto>.New().With(c => c.Curso, _curso).Build();
            _pessoa = FluentBuilder<Pessoa>.New().With(a => a.TipoDePublico, "Medico(a)").Build();
            _estaPago = true;
            _valorPago = 1050.30m;
            _comoFicouSabendo = FluentBuilder<ComoFicouSabendo>.New().Build();
        }

        [TestMethod]
        public void DeveCriarMatricula()
        {
            var matricula = new Matricula(_cursoAberto, _pessoa, _estaPago, _valorPago, _comoFicouSabendo);

            Assert.AreEqual(_cursoAberto, matricula.CursoAberto);
            Assert.AreEqual(_pessoa, matricula.Pessoa);
            Assert.AreEqual(DateTime.Now.Date, matricula.DataDeCriacao.Date);
            Assert.AreEqual(_estaPago, matricula.EstaPago);
            Assert.AreEqual(_valorPago, matricula.ValorPago);
            Assert.AreEqual(_comoFicouSabendo, matricula.ComoFicouSabendo);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaQuandoTipoDePublicoDoAlunoECursoSaoDiferentes()
        {
            var publicosAlvo = new List<PublicoAlvoParaCurso> {new PublicoAlvoParaCurso("Medico(a)")};
            var cursoParaMedico = FluentBuilder<Curso>.New().With(c => c.PublicosAlvo, publicosAlvo);
            var cursoAberto = FluentBuilder<CursoAberto>.New().With(c => c.Curso, cursoParaMedico).Build();
            var alunoEnfermeiro = FluentBuilder<Pessoa>.New().With(a => a.TipoDePublico, "Enfermeiro(a)").Build();

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Matricula(cursoAberto, alunoEnfermeiro, _estaPago, _valorPago, null))
                .Message;
            Assert.AreEqual("Tipo de publíco alvo do Curso e do Aluno são diferentes", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaSemCursoAberto()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Matricula(null, _pessoa, _estaPago, _valorPago, null))
                .Message;

            Assert.AreEqual("Curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaSemAluno()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Matricula(_cursoAberto, null, _estaPago, _valorPago, null))
                .Message;

            Assert.AreEqual("Aluno é obrigatório", message);
        }

        [TestMethod]
        public void DevePoderAdicionarObservacao()
        {
            const string observacao = "observacao";
            var matricula = FluentBuilder<Matricula>.New().Build();

            matricula.AdicionarObservacao(observacao);

            Assert.AreEqual(observacao, matricula.Observacao);
        }

        [TestMethod]
        public void NaoDeveAdicionarObservacaoVazia()
        {
            var matricula = FluentBuilder<Matricula>.New().Build();

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => matricula.AdicionarObservacao(null)).Message;
            Assert.AreEqual("Observação é obrigatório", message);
        }

        [TestMethod]
        public void DevePoderAdicionarNotaDoAlunoNoCursoESeAprovado()
        {
            const float notaDoAlunoNoCurso = 97.50f;
            var matricula = FluentBuilder<Matricula>.New().Build();

            matricula.AdicionarNotaDoAlunoNoCurso(notaDoAlunoNoCurso, StatusDaAprovacaoDaMatricula.Aprovado);

            Assert.AreEqual(notaDoAlunoNoCurso, matricula.NotaDoAlunoNoCurso);
            Assert.AreEqual(StatusDaAprovacaoDaMatricula.Aprovado, matricula.StatusDaAprovacao);
        }

        [TestMethod]
        public void NaoDeveAdicionarNotaInvalidaDoAlunoNoCurso()
        {
            var matricula = FluentBuilder<Matricula>.New().Build();

            var message0 = Assert.ThrowsException<ExcecaoDeDominio>(() => matricula.AdicionarNotaDoAlunoNoCurso(0, StatusDaAprovacaoDaMatricula.Aprovado)).Message;
            Assert.AreEqual("Nota do aluno no curso é inválido", message0);

            var message11 = Assert.ThrowsException<ExcecaoDeDominio>(() => matricula.AdicionarNotaDoAlunoNoCurso(101, StatusDaAprovacaoDaMatricula.Aprovado)).Message;
            Assert.AreEqual("Nota do aluno no curso é inválido", message11);
        }

        [TestMethod]
        public void NaoDeveAdicionarStatusDeAprovacaoDaMatriculaInvalida()
        {
            var matricula = FluentBuilder<Matricula>.New().Build();

            Assert.ThrowsException<ExcecaoDeDominio>(() => matricula.AdicionarNotaDoAlunoNoCurso(1, StatusDaAprovacaoDaMatricula.Nenhum))
                .Message.StartsWith("Status de aprovação é inválido");
        }

        [TestMethod]
        public void DevePoderInformarSeAlunoEhUmInstrutorEmPotencial()
        {
            const bool ip = true;
            var matricula = FluentBuilder<Matricula>.New().Build();

            matricula.EhInstrutorEmPotencial(ip);

            Assert.AreEqual(ip, matricula.Ip);
        }

        [TestMethod]
        public void DeveSerPossivelCancelarMatricula()
        {
            var matricula = FluentBuilder<Matricula>.New().Build();

            matricula.CancelarMatricula();

            Assert.IsTrue(matricula.Cancelada);
        }
    }
}
