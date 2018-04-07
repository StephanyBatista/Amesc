using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Amesc.Dominio.Pessoas;
using Moq;
using Nosbor.FluentBuilder.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Amesc.DominioTestes.Matriculas
{
    [TestClass]
    public class CriacaoDeMatriculaTeste
    {
        private int _idAluno;
        private bool _estaPago;
        private int _idCursoAberto;
        private Pessoa _pessoa;
        private CursoAberto _cursoAberto;
        private CriacaoDeMatricula _criacaoDeMatricula;
        private Mock<IPessoaRepositorio> _alunoRepositorio;
        private Mock<IMatriculaRepositorio> _matriculaRepositorio;
        private Mock<ICursoAbertoRepositorio> _cursoAbertoRepositorio;
        private decimal _valorPago;

        [TestInitialize]
        public void Setup()
        {
            _pessoa = FluentBuilder<Pessoa>.New().With(a => a.TipoDePublico, "Medico(a)").Build();
            var cursoAbertoMock = new Mock<CursoAberto>();
            cursoAbertoMock.Setup(c => c.ContemPublicoAlvo(_pessoa.TipoDePublico)).Returns(true);
            _cursoAberto = cursoAbertoMock.Object;
            _estaPago = true;
            _valorPago = 100m;
            _idCursoAberto = 100;
            _idAluno = 600;

            _matriculaRepositorio = new Mock<IMatriculaRepositorio>();
            _cursoAbertoRepositorio = new Mock<ICursoAbertoRepositorio>();
            _cursoAbertoRepositorio.Setup(r => r.ObterPorId(_idCursoAberto)).Returns(_cursoAberto);
            _alunoRepositorio = new Mock<IPessoaRepositorio>();
            _alunoRepositorio.Setup(r => r.ObterPorId(_idAluno)).Returns(_pessoa);

            _criacaoDeMatricula = 
                new CriacaoDeMatricula(_matriculaRepositorio.Object, _cursoAbertoRepositorio.Object, _alunoRepositorio.Object);
        }

        [TestMethod]
        public void DeveSalvarMatricula()
        {
            _criacaoDeMatricula.Criar(_idCursoAberto, _idAluno, _estaPago, _valorPago.ToString());

            _matriculaRepositorio.Verify(
                r => r.Adicionar(
                    It.Is<Matricula>(
                        m => m.CursoAberto == _cursoAberto && 
                        m.Pessoa == _pessoa && 
                        m.EstaPago == _estaPago)));
        }
    }
}
