﻿using System;
using System.Collections.Generic;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Amesc.Dominio._Base;
using Castle.Components.DictionaryAdapter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Matriculas
{
    [TestClass]
    public class MatriculaTeste
    {
        private CursoAberto _cursoAberto;
        private Aluno _aluno;
        private bool _estaPago;
        private FluentBuilder<Curso> _curso;

        [TestInitialize]
        public void Setup()
        {
            _curso = FluentBuilder<Curso>.New().With(c => c.PublicosAlvo,
                new List<PublicoAlvoParaCurso> {new PublicoAlvoParaCurso("Medico(a)")});
            _cursoAberto = FluentBuilder<CursoAberto>.New().With(c => c.Curso, _curso).Build();
            _aluno = FluentBuilder<Aluno>.New().With(a => a.TipoDePublico, "Medico(a)").Build();
            _estaPago = true;
        }

        [TestMethod]
        public void DeveCriarMatricula()
        {
            var matricula = new Matricula(_cursoAberto, _aluno, _estaPago);

            Assert.AreEqual(_cursoAberto, matricula.CursoAberto);
            Assert.AreEqual(_aluno, matricula.Aluno);
            Assert.AreEqual(DateTime.Now.Date, matricula.DataDeCriacao.Date);
            Assert.AreEqual(_estaPago, matricula.EstaPago);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaQuandoTipoDePublicoDoAlunoECursoSaoDiferentes()
        {
            var publicosAlvo = new List<PublicoAlvoParaCurso> {new PublicoAlvoParaCurso("Medico(a)")};
            var cursoParaMedico = FluentBuilder<Curso>.New().With(c => c.PublicosAlvo, publicosAlvo);
            var cursoAberto = FluentBuilder<CursoAberto>.New().With(c => c.Curso, cursoParaMedico).Build();
            var alunoEnfermeiro = FluentBuilder<Aluno>.New().With(a => a.TipoDePublico, "Enfermeiro(a)").Build();

            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Matricula(cursoAberto, alunoEnfermeiro, _estaPago))
                .Message;
            Assert.AreEqual("Tipo de publíco alvo do Curso e do Aluno são diferentes", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaSemCursoAberto()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Matricula(null, _aluno, _estaPago))
                .Message;

            Assert.AreEqual("Curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarMatriculaSemAluno()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => new Matricula(_cursoAberto, null, _estaPago))
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
        public void DevePoderAdicionarNotaDoAlunoNoCurso()
        {
            const float notaDoAlunoNoCurso = 7.5f;
            var matricula = FluentBuilder<Matricula>.New().Build();

            matricula.AdicionarNotaDoAlunoNoCurso(notaDoAlunoNoCurso);

            Assert.AreEqual(notaDoAlunoNoCurso, matricula.NotaDoAlunoNoCurso);
        }

        [TestMethod]
        public void NaoDeveAdicionarNotaInvalidaDoAlunoNoCurso()
        {
            var matricula = FluentBuilder<Matricula>.New().Build();

            var message0 = Assert.ThrowsException<ExcecaoDeDominio>(() => matricula.AdicionarNotaDoAlunoNoCurso(0)).Message;
            Assert.AreEqual("Nota do aluno no curso é inválido", message0);

            var message11 = Assert.ThrowsException<ExcecaoDeDominio>(() => matricula.AdicionarNotaDoAlunoNoCurso(11)).Message;
            Assert.AreEqual("Nota do aluno no curso é inválido", message11);
        }
    }
}