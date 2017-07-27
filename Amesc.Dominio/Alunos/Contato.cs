using Amesc.Dominio._Base;

namespace Amesc.Dominio.Alunos
{
    public class Contato : Entidade
    {
        public string Telefone { get; set; }
        public string Endereco { get; set; }

        public Contato() { }

        public Contato(string telefone, string endereco)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(telefone), "Telefone é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(endereco), "Endereço é obrigatório");

            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
