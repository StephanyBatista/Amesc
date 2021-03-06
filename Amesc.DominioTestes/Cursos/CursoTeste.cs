﻿using System.Collections.Generic;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class CursoTeste
    {
        private string _codigo;
        private string _nome;
        private string _descricao;
        private decimal _precoSugerido;
        private string _requisitos;
        private int _periodoValidoEmAno;
        private List<string> _publicosAlvo;
        private Curso _curso;

        [TestInitialize]
        public void Setup()
        {
            _codigo = "AAXD";
            _nome = "Curso A";
            _descricao = "Descrição A";
            _precoSugerido = 1000m;
            _publicosAlvo = new List<string>{"Médico(a)"};
            _requisitos = "pagar antes";
            _periodoValidoEmAno = 1;
            _curso = FluentBuilder<Curso>.New().Build();
        }

        [TestMethod]
        public void DeveCriarUmCurso()
        {
            var curso = new Curso(_codigo, _nome, _descricao, _precoSugerido, _publicosAlvo, _requisitos, _periodoValidoEmAno);

            Assert.AreEqual(_codigo, curso.Codigo);
            Assert.AreEqual(_nome, curso.Nome);
            Assert.AreEqual(_descricao, curso.Descricao);
            Assert.AreEqual(_requisitos, curso.Requisitos);
            Assert.AreEqual(_periodoValidoEmAno, curso.PeriodoValidoEmAno);
            //Testar
            //CollectionAssert.AreEqual(curso.PublicosAlvo, _publicosAlvo);
        }

        [TestMethod]
        public void DeveInformarQueCursoContemPublicoAlvo()
        {
            var curso = new Curso(_codigo, _nome, _descricao, _precoSugerido, _publicosAlvo, _requisitos, _periodoValidoEmAno);

            Assert.IsTrue(curso.ContemPublicoAlvo("Médico(a)"));
        }

        [TestMethod]
        public void DeveCriarUmCursoSemPublicoAlvo()
        {
            var curso = new Curso(_codigo, _nome, _descricao, _precoSugerido, null, _requisitos, _periodoValidoEmAno);

            Assert.IsNull(curso.PublicosAlvo);
        }

        [TestMethod]
        public void NaoDeveCriarCursoSemNome()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                new Curso(_codigo, null, _descricao, _precoSugerido, _publicosAlvo, _requisitos, _periodoValidoEmAno))
                .Message;

            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoSemDescricao()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                new Curso(_codigo, _nome, null, _precoSugerido, _publicosAlvo, _requisitos, _periodoValidoEmAno))
                .Message;

            Assert.AreEqual("Descrição é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoSemRequisitos()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                new Curso(_codigo, _nome, _descricao, _precoSugerido, _publicosAlvo, null, _periodoValidoEmAno))
                .Message;

            Assert.AreEqual("Requisitos são obrigatórios", message);
        }

        [TestMethod]
        public void DeveEditarCurso()
        {
            var curso = FluentBuilder<Curso>.New().Build();

            curso.Editar(_codigo, _nome, _descricao, _precoSugerido, _publicosAlvo, _requisitos, _periodoValidoEmAno);

            Assert.AreEqual(curso.Codigo, _codigo);
            Assert.AreEqual(curso.Nome, _nome);
            Assert.AreEqual(curso.Descricao, _descricao);
            Assert.AreEqual(_requisitos, curso.Requisitos);
            Assert.AreEqual(_periodoValidoEmAno, curso.PeriodoValidoEmAno);
            //Testar
            //CollectionAssert.AreEqual(curso.PublicosAlvo, _publicosAlvo);
        }

        [TestMethod]
        public void NaoDeveEditarCursoSemNome()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _curso.Editar(_codigo, null, _descricao, _precoSugerido, _publicosAlvo, _requisitos, _periodoValidoEmAno))
                .Message;

            Assert.AreEqual("Nome é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoSemDescricao()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _curso.Editar(_codigo, _nome, null, _precoSugerido, _publicosAlvo, _requisitos, _periodoValidoEmAno))
                .Message;

            Assert.AreEqual("Descrição é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoSemRequisitos()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _curso.Editar(_codigo, _nome, _descricao, _precoSugerido, _publicosAlvo, null, _periodoValidoEmAno))
                .Message;

            Assert.AreEqual("Requisitos são obrigatórios", message);
        }
    }
}
