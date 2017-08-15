using Amesc.Dominio._Base;

namespace Amesc.Dominio.Alunos
{
    public class Endereco : Entidade
    {
        public string Numero { get; private set; }
        public string Logradouro { get; private set; }
        public string Bairro { get; private set; }
        public string Complemento { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }

        public Endereco() { }

        public Endereco(string numero, string logradouro, string bairro, string complemento, string cidade, string estado)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(numero), "Número do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(logradouro), "Logradouro do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(bairro), "Bairro do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(cidade), "Cidade do endereço é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(estado), "Estado do endereço é obrigatório");

            Numero = numero;
            Logradouro = logradouro;
            Bairro = bairro;
            Complemento = complemento;
            Cidade = cidade;
            Estado = estado;
        }
    }
}
