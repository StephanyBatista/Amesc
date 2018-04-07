using System;

namespace Amesc.Dominio.Pessoas
{
    public class ArmazenadorDePessoa
    {
        private readonly IRepositorio<Pessoa> _alunoRepositorio;

        public ArmazenadorDePessoa(IRepositorio<Pessoa> alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public void Armazenar(
            int id, 
            string nome, 
            string cpf, 
            string orgaoEmissorDoRg,
            string rg,
            string dataDeNascimentoEmString,
            string registroProfissional,
            string telefone, 
            string numero, 
            string logradouro,
            string cep,
            string bairro, 
            string complemento, 
            string cidade, 
            string estado, 
            string publicoAlvo,
            string especialidade,
            string midiaSocial,
            TipoDePessoa tipoDePessoa)
        {
            DateTime.TryParse(dataDeNascimentoEmString, out DateTime dataDeNascimento);

            if (id == 0)
            {
                var endereço = new Endereco(numero, logradouro, cep, bairro, complemento, cidade, estado);
                var aluno = new Pessoa(
                    nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, registroProfissional, telefone, endereço, 
                    publicoAlvo, especialidade, midiaSocial, tipoDePessoa);
                _alunoRepositorio.Adicionar(aluno);
            }
            else
            {
                var endereco = new Endereco(numero, logradouro, cep, bairro, complemento, cidade, estado);
                var aluno = _alunoRepositorio.ObterPorId(id);
                aluno.Editar(
                    nome, cpf, orgaoEmissorDoRg, rg, dataDeNascimento, registroProfissional, telefone, endereco, 
                    publicoAlvo, especialidade, midiaSocial);
            }
        }
    }
}