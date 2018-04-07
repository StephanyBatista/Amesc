using Amesc.Dominio;
using Amesc.Dominio.Pessoas;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Nosbor.FluentBuilder.Lib;

namespace Amesc.DominioTestes.Pessoas
{
    [TestClass]
    public class ArmazenadorDePessoaTeste
    {
        private string _nome;
        private string _cpf;
        private string _telefone;
        private string _numero;
        private Mock<IRepositorio<Pessoa>> _alunoRepositorio;
        private string _publicoAlvo;
        private ArmazenadorDePessoa _armazenador;
        private string _logradouro;
        private string _cep;
        private string _bairro;
        private string _complemento;
        private string _cidade;
        private string _estado;
        private string _orgaoEmissorDoRg;
        private string _rg;
        private string _registroProfissional;
        private string _dataDeNascimento;
        private string _midiaSocial;
        private string _especialidade;

        [TestInitialize]
        public void Setup()
        {
            _nome = "Teste";
            _cpf = "01";
            _telefone = "01";
            _numero = "76";
            _logradouro = "Doutor";
            _cep = "79033-231";
            _bairro = "Mata";
            _complemento = string.Empty;
            _cidade = "Campo Grande";
            _estado = "MS";
            _publicoAlvo = "Medico(a)";
            _orgaoEmissorDoRg = "MS";
            _rg = "001336781";
            _registroProfissional = "aaxx";
            _dataDeNascimento = "25/11/1985";
            _midiaSocial = "facebook";
            _especialidade = "medico";

            _alunoRepositorio = new Mock<IRepositorio<Pessoa>>();
            _armazenador = new ArmazenadorDePessoa(_alunoRepositorio.Object);
        }

        [TestMethod]
        public void DeveSalvarAluno()
        {
            const int id = 0;

            _armazenador.Armazenar(
                id, _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _numero, _logradouro, _cep, _bairro, _complemento, _cidade, _estado, 
                _publicoAlvo, _especialidade, _midiaSocial, TipoDePessoa.Aluno);

            _alunoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<Pessoa>()));
        }

        [TestMethod]
        public void DeveEditarAluno()
        {
            const int id = 1;
            _alunoRepositorio.Setup(repositorio => repositorio.ObterPorId(id))
                .Returns(FluentBuilder<Pessoa>.New().Build());

            _armazenador.Armazenar(id, _nome, _cpf, _orgaoEmissorDoRg, _rg, _dataDeNascimento, _registroProfissional, _telefone, _numero, _logradouro, _cep, _bairro, _complemento, _cidade, _estado,
                _publicoAlvo, _especialidade, _midiaSocial, TipoDePessoa.Aluno);

            _alunoRepositorio.Verify(repositorio => repositorio.Adicionar(It.IsAny<Pessoa>()), Times.Never);
        }
    }
}
