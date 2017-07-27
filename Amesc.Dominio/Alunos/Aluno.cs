using Amesc.Dominio.Cursos;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Alunos
{
    public class Aluno : Entidade
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Contato Contato { get; private set; }
        public string TipoDePublico { get; private set; }

        public Aluno() { }

        public Aluno(string nome, string cpf, string telefone, string endereco, string tipoDePublico)
        {
            Contato = new Contato(telefone, endereco);
            Validar(nome, cpf, tipoDePublico);
            Atribuir(nome, cpf, tipoDePublico);
        }

        public void Editar(string nome, string cpf, string telefone, string endereco, string tipoDePublico)
        {
            Contato = new Contato(telefone, endereco);
            Validar(nome, cpf, tipoDePublico);
            Atribuir(nome, cpf, tipoDePublico);
        }

        private static void Validar(string nome, string cpf, string tipoDePublico)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(cpf), "CPF é obrigatório");
            ExcecaoDeDominio.Quando(tipoDePublico == null, "Tipo de publico é obrigatório");
        }

        private void Atribuir(string nome, string cpf, string tipoDePublico)
        {
            Nome = nome;
            Cpf = cpf;
            TipoDePublico = tipoDePublico;
        }
    }
}