using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Moq;
using System;
using System.Collections.Generic;
using Amesc.Dominio.Cursos.Instrutores;
using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio.Pessoas;
using Nosbor.FluentBuilder.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class ArmazenadorDeCursoAbertoTeste
    {
        const int InstrutorId = 5;
        private Mock<IRepositorio<Curso>> _cursoRepositorio;
        private Mock<ICursoAbertoRepositorio> _cursoAbertoRepositorio;
        private ArmazenadorDeCursoAberto _armazenador;
        private CursoAbertoParaCadastroViewModel _dto;
        private Mock<IPessoaRepositorio> _instrutorRepositorio;
        private Pessoa _instrutor;

        [TestInitialize]
        public void Setup()
        {
            _dto = new CursoAbertoParaCadastroViewModel
            {
                Preco = "10",
                Codigo = "XPTO",
                IdCurso = 10,
                PeriodoFinalParaMatricula = DateTime.Now.AddDays(-1),
                PeriodoInicialParaMatricula = DateTime.Now.AddDays(-10),
                InicioDoCurso = DateTime.Now,
                FimDoCurso = DateTime.Now.AddDays(10),
                TipoDeCursoAberto = "Publico"
            };

            _cursoRepositorio = new Mock<IRepositorio<Curso>>();
            _cursoRepositorio.Setup(repositorio => repositorio.ObterPorId(_dto.IdCurso))
                .Returns(FluentBuilder<Curso>.New().Build);
            _cursoAbertoRepositorio = new Mock<ICursoAbertoRepositorio>();

            _instrutorRepositorio = new Mock<IPessoaRepositorio>();
            _instrutor = FluentBuilder<Pessoa>.New().With(i => i.Id, InstrutorId).Build();
            _instrutorRepositorio.Setup(r => r.ObterPorId(InstrutorId)).Returns(_instrutor);

            _armazenador = new ArmazenadorDeCursoAberto(_cursoRepositorio.Object, _cursoAbertoRepositorio.Object, _instrutorRepositorio.Object);
        }

        [TestMethod]
        public void DeveSalvarCursoAberto()
        {
            _dto.Id = 0;
            _armazenador.Armazenar(_dto);

            _cursoAbertoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<CursoAberto>()));
        }

        [TestMethod]
        public void DeveSalvarCursoAbertoComInstrutores()
        {
            _dto.Id = 0;
            _dto.Instrutores = new List<InstrutorDaTurmaViewModel>
            {
                new InstrutorDaTurmaViewModel{ Cargo = "Diretor", Id = InstrutorId}
            };
            _armazenador.Armazenar(_dto);

            _cursoAbertoRepositorio.Verify(repositorio => 
                repositorio.Adicionar(It.Is<CursoAberto>(c => 
                    c.Instrutores.Exists(i => i.Instrutor == _instrutor && i.Cargo == CargoNaTurma.Diretor))));
        }

        [TestMethod]
        public void DeveEditarCursoAberto()
        {
            _dto.Id = 7;
            _cursoAbertoRepositorio.Setup(repositorio => repositorio.ObterPorId(_dto.Id))
                .Returns(FluentBuilder<CursoAberto>.New().Build());

            _armazenador.Armazenar(_dto);

            _cursoAbertoRepositorio.Verify(repositorio => 
                repositorio.Adicionar(It.IsAny<CursoAberto>()), Times.Never);
        }

        [TestMethod]
        public void DeveEditarCursoAbertoComInstrutores()
        {
            _dto.Id = 7;
            _dto.Instrutores = new List<InstrutorDaTurmaViewModel>
            {
                new InstrutorDaTurmaViewModel{ Cargo = "Diretor", Id = InstrutorId}
            };
            var cursoAberto = FluentBuilder<CursoAberto>.New().Build();
            _cursoAbertoRepositorio.Setup(repositorio => repositorio.ObterPorId(_dto.Id))
                .Returns(cursoAberto);

            _armazenador.Armazenar(_dto);

            Assert.IsTrue(cursoAberto.Instrutores.Exists(i => i.Instrutor == _instrutor && i.Cargo == CargoNaTurma.Diretor));
        }

        [TestMethod]
        public void DeveRemoverInstrutoresQueNaoEstiverContidoNoModeloDoCliente()
        {
            _dto.Id = 7;
            
            _dto.Instrutores = new List<InstrutorDaTurmaViewModel>
            {
                new InstrutorDaTurmaViewModel{ Cargo = "Diretor", Id = InstrutorId}
            };
            var instrutorParaRemocao = FluentBuilder<Pessoa>.New().With(i => i.Id, 56).Build();
            var cursoAberto = FluentBuilder<CursoAberto>.New().Build();
            cursoAberto.AdicionarInstrutor(instrutorParaRemocao, CargoNaTurma.Coordenador);

            _cursoAbertoRepositorio.Setup(repositorio => repositorio.ObterPorId(_dto.Id))
                .Returns(cursoAberto);

            _armazenador.Armazenar(_dto);

            Assert.IsFalse(cursoAberto.Instrutores.Exists(i => i.Instrutor == instrutorParaRemocao && i.Cargo == CargoNaTurma.Coordenador));
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoPrecoNulo()
        {
            _dto.Id = 0;
            _dto.Preco = null;
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _armazenador.Armazenar(_dto))
                .Message;

            Assert.AreEqual("Preço inválido", message);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoPrecoInvalido()
        {
            _dto.Id = 0;
            _dto.Preco = "PREÇO INVÁLIDO";
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() => 
                _armazenador.Armazenar(_dto))
                .Message;

            Assert.AreEqual("Preço inválido", message);
        }

        [TestMethod]
        public void NaoDeveSalvarCursoAbertoQuandoTipoInvalido()
        {
            _dto.Id = 0;
            _dto.TipoDeCursoAberto = "ENUM INVÁLIDO";
            var message = Assert.ThrowsException<ExcecaoDeDominio>(() =>
                    _armazenador.Armazenar(_dto))
                .Message;

            Assert.AreEqual("Tipo de curso inválido", message);
        }
    }
}
