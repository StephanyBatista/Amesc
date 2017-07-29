using Amesc.Dominio._Base;

namespace Amesc.Dominio.Alunos
{
    public class Contato : Entidade
    {
        public string Telefone { get; private set; }
        public string Endereco { get; private set; }

        public Contato() { }

        public Contato(string telefone, string endereco)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(telefone), "Telefone é obrigatório");

            Telefone = telefone;
            Endereco = endereco;
        }
    }
}
