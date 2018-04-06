using Amesc.Dominio._Base;

namespace Amesc.Dominio.Cursos.Instrutores
{
    public class Instrutor : Entidade
    {
        public string Codigo { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }

        private Instrutor() { }

        public Instrutor(string codigo, string nome, string email)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome do instrutor é obrigatório");

            Codigo = codigo;
            Nome = nome;
            Email = email;
        }

        public void Editar(string codigo, string nome, string email)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome do instrutor é obrigatório");

            Codigo = codigo;
            Nome = nome;
            Email = email;
        }
    }
}