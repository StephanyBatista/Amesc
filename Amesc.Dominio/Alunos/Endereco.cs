using System;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Alunos
{
    public class Endereco
    {
        public string Numero { get; private set; }
        public string Logradouro { get; private set; }
        public string Cep { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco() { }

        public Endereco(string numero, string logradouro, string cep, string bairro, string complemento, string cidade, string estado)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(numero), "Número do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(logradouro), "Logradouro do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(cep), "CEP do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(bairro), "Bairro do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(cidade), "Cidade do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(estado), "Estado do endereço é obrigatório");

            Numero = numero;
            Logradouro = logradouro;
            Cep = cep;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
        }

        internal void AlterarNumero(string numero)
        {
            Numero = numero;
        }

        internal void AlterarLogradouro(string logradouro)
        {
            Logradouro = logradouro;
        }

        internal void AlterarBairro(string bairro)
        {
            Bairro = bairro;
        }

        internal void AlterarComplemento(string complemento)
        {
            Complemento = complemento;
        }

        internal void AlterarCidade(string cidade)
        {
            Cidade = cidade;
        }

        internal void AlterarEstado(string estado)
        {
            Estado = estado;
        }

        internal void AlterarCep(string cep)
        {
            Cep = cep;
        }
    }
}
