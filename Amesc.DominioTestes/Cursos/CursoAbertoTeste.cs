using System;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Cursos
{
    [TestClass]
    public class CursoAbertoTeste
    {
        private Curso _curso;
        private decimal _preco;
        private string _empresa;
        private DateTime _periodoInicialParaMatricula;
        private DateTime _periodoFinalParaMatricula;
        private DateTime _dataDeInicioDoCurso;
        private DateTime _dataDeFimDoCurso;
        private CursoAberto _cursoAberto;
        private TipoDeCursoAberto _tipoDeCursoAberto;
        private string _codigo;

        [TestInitialize]
        public void Setup()
        {
            _codigo = "XPTO";
            _preco = 1000m;
            _empresa = "Empresa";
            _tipoDeCursoAberto = TipoDeCursoAberto.Publico;
            _curso = FluentBuilder<Curso>.New().Build();
            _periodoInicialParaMatricula = DateTime.Now.AddDays(-1);
            _periodoFinalParaMatricula = DateTime.Now;
            _dataDeInicioDoCurso = DateTime.Now.AddDays(+1);
            _dataDeFimDoCurso = DateTime.Now.AddDays(+10);
            _cursoAberto = FluentBuilder<CursoAberto>.New().Build();
        }

        [TestMethod]
        public void DeveCriarCursoAberto()
        {
            var cursoAberto = new CursoAberto(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, _dataDeInicioDoCurso, _dataDeFimDoCurso);

            Assert.AreEqual(_codigo, cursoAberto.Codigo);
            Assert.AreEqual(_curso, cursoAberto.Curso);
            Assert.AreEqual(_preco, cursoAberto.Preco);
            Assert.AreEqual(_periodoInicialParaMatricula, cursoAberto.PeriodoInicialParaMatricula);
            Assert.AreEqual(_periodoFinalParaMatricula, cursoAberto.PeriodoFinalParaMatricula);
            Assert.AreEqual(_dataDeInicioDoCurso, cursoAberto.InicioDoCurso);
            Assert.AreEqual(_dataDeFimDoCurso, cursoAberto.FimDoCurso);
            Assert.AreEqual(_tipoDeCursoAberto, cursoAberto.Tipo);
        }

        [TestMethod]
        public void DeveEditarCursoAberto()
        {
            _cursoAberto.Editar(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, _dataDeInicioDoCurso, _dataDeFimDoCurso);

            Assert.AreEqual(_curso, _cursoAberto.Curso);
            Assert.AreEqual(_preco, _cursoAberto.Preco);
            Assert.AreEqual(_periodoInicialParaMatricula, _cursoAberto.PeriodoInicialParaMatricula);
            Assert.AreEqual(_periodoFinalParaMatricula, _cursoAberto.PeriodoFinalParaMatricula);
            Assert.AreEqual(_dataDeInicioDoCurso, _cursoAberto.InicioDoCurso);
            Assert.AreEqual(_dataDeFimDoCurso, _cursoAberto.FimDoCurso);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoSemCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_codigo, null, _preco, TipoDeCursoAberto.Publico, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoSemCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_codigo, null, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoSemPreco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_codigo, _curso, 0, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Preço do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoSemPreco()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_codigo, _curso, 0, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Preço do curso inválido", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoSemPeriodoInicialParaMatricula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_codigo, _curso, _preco, _tipoDeCursoAberto, null, null, _periodoFinalParaMatricula, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Período inicial para matricula é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoSemPeriodoInicialParaMatricula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_codigo, _curso, _preco, _tipoDeCursoAberto, null, null, _periodoFinalParaMatricula, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Período inicial para matricula é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoSemPeriodoFinalParaMatricula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new CursoAberto(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, null, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Período final para matricula é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoSemPeriodoFinalParaMatricula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _cursoAberto.Editar(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, null, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Período final para matricula é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoComPeriodoInicialMaiorQuePeriodoFinalParaMatricula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_codigo, _curso, _preco, _tipoDeCursoAberto, null, DateTime.Now.AddDays(+5), DateTime.Now, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Período inicial é maior que período final para matricula", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoComPeriodoInicialMaiorQuePeriodoFinalParaMatricula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_codigo, _curso, _preco, _tipoDeCursoAberto, null, DateTime.Now.AddDays(+5), DateTime.Now, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Período inicial é maior que período final para matricula", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoSemDataDeInicioDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, DateTime.MinValue, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Data de inicio do curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoSemDataDeInicioDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, DateTime.MinValue, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Data de inicio do curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoSemDataDeFimDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new CursoAberto(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, _dataDeInicioDoCurso, DateTime.MinValue))
                .Message;

            Assert.AreEqual("Data de fim do curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoSemDataDeFimDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _cursoAberto.Editar(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, _dataDeInicioDoCurso, DateTime.MinValue))
                .Message;

            Assert.AreEqual("Data de fim do curso é obrigatório", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoComDataDeInicioDoCursoMenorQuePeriodoFinalParaMatricula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => new CursoAberto(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, DateTime.Now.AddDays(-3), _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Data de inicio do curso menor que período final para matricula", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoComDataDeInicioDoCursoMenorQuePeriodoFinalParaMatricula()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                () => _cursoAberto.Editar(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, DateTime.Now.AddDays(-3), _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Data de inicio do curso menor que período final para matricula", message);
        }

        [TestMethod]
        public void NaoDeveCriarCursoAbertoComDataDeInicioDoCursoMaiorQueDataDeFimDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new CursoAberto(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, DateTime.Now.AddDays(+5), DateTime.Now))
                .Message;

            Assert.AreEqual("Data de inicio do curso maior que data de fim do curso", message);
        }

        [TestMethod]
        public void NaoDeveEditarCursoAbertoComDataDeInicioDoCursoMaiorQueDataDeFimDoCurso()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _cursoAberto.Editar(_codigo, _curso, _preco, _tipoDeCursoAberto, null, _periodoInicialParaMatricula, _periodoFinalParaMatricula, DateTime.Now.AddDays(+5), DateTime.Now))
                .Message;

            Assert.AreEqual("Data de inicio do curso maior que data de fim do curso", message);
        }

        [TestMethod]
        public void NaoDeveObrigarNaCriacaoPeriodoInicialEFinalParaMatriculaQuandoTipoDeCursoEhFechado()
        {
            var cursoAberto = new CursoAberto(_codigo, _curso, _preco, TipoDeCursoAberto.Fechado, _empresa, null, null, _dataDeInicioDoCurso, _dataDeFimDoCurso);

            Assert.IsNull(cursoAberto.PeriodoInicialParaMatricula);
            Assert.IsNull(cursoAberto.PeriodoFinalParaMatricula);
        }

        [TestMethod]
        public void NaoDeveObrigarNaEdicaoPeriodoInicialEFinalParaMatriculaQuandoTipoDeCursoEhFechado()
        {
            _cursoAberto.Editar(_codigo, _curso, _preco, TipoDeCursoAberto.Fechado, _empresa, null, null, _dataDeInicioDoCurso, _dataDeFimDoCurso);

            Assert.IsNull(_cursoAberto.PeriodoInicialParaMatricula);
            Assert.IsNull(_cursoAberto.PeriodoFinalParaMatricula);
        }

        [TestMethod]
        public void DeveObrigarNaCriacaoInformarONomeDaEmpresaQuandoTipoDeCursoEhFechad()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => new CursoAberto(_codigo, _curso, _preco, TipoDeCursoAberto.Fechado, null, null, null, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;
            
            Assert.AreEqual("Empresa é obrigatório quando tipo é fechado", message);
        }

        [TestMethod]
        public void DeveObrigarNaEdicaoInformarONomeDaEmpresaQuandoTipoDeCursoEhFechad()
        {
            var message = Assert.ThrowsException<ExcecaoDeDominio>(
                    () => _cursoAberto.Editar(_codigo, _curso, _preco, TipoDeCursoAberto.Fechado, null, null, null, _dataDeInicioDoCurso, _dataDeFimDoCurso))
                .Message;

            Assert.AreEqual("Empresa é obrigatório quando tipo é fechado", message);
        }
    }
}
