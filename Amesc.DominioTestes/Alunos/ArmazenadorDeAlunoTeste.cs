using System.Linq;
using Amesc.Dominio;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Alunos
{
    [TestClass]
    public class ArmazenadorDeAlunoTeste
    {
        private string _nome;
        private string _cpf;
        private string _telefone;
        private string _numero;
        private Mock<IRepositorio<Aluno>> _alunoRepositorio;
        private string _publicoAlvo;
        private ArmazenadorDeAluno _armazenador;
        private string _logradouro;
        private string _bairro;
        private string _complemento;
        private string _cidade;
        private string _estado;

        [TestInitialize]
        public void Setup()
        {
            _nome = "Teste";
            _cpf = "01";
            _telefone = "01";
            _numero = "76";
            _logradouro = "Doutor";
            _bairro = "Mata";
            _complemento = string.Empty;
            _cidade = "Campo Grande";
            _estado = "MS";
            _publicoAlvo = "Medico(a)";

            _alunoRepositorio = new Mock<IRepositorio<Aluno>>();
            _armazenador = new ArmazenadorDeAluno(_alunoRepositorio.Object);
        }

        [TestMethod]
        public void DeveSalvarAluno()
        {
            const int id = 0;

            _armazenador.Armazenar(id, _nome, _cpf, _telefone, _numero, _logradouro, _bairro, _complemento, _cidade, _estado, _publicoAlvo);

            _alunoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<Aluno>()));
        }

        [TestMethod]
        public void DeveEditarAluno()
        {
            const int id = 1;
            _alunoRepositorio.Setup(repositorio => repositorio.ObterPorId(id))
                .Returns(FluentBuilder<Aluno>.New().Build());

            _armazenador.Armazenar(id, _nome, _cpf, _telefone, _numero, _logradouro, _bairro, _complemento, _cidade, _estado, _publicoAlvo);

            _alunoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<Aluno>()), Times.Never);
        }
    }
}
