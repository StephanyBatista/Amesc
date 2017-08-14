using Amesc.Dominio._Base;

namespace Amesc.Dominio.Alunos
{
    public class Aluno : Entidade
    {
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public Endereco Endereco { get; private set; }
        public string TipoDePublico { get; private set; }
        public string Telefone { get; set; }

        public Aluno() { }

        public Aluno(string nome, string cpf, string telefone, Endereco endereco, string tipoDePublico)
        {
            Validar(nome, cpf, telefone, endereco, tipoDePublico);
            Atribuir(nome, cpf, telefone, endereco, tipoDePublico);
        }

        public void Editar(string nome, string cpf, string telefone, Endereco endereco, string tipoDePublico)
        {
            Validar(nome, cpf, telefone, endereco, tipoDePublico);
            Atribuir(nome, cpf, telefone, endereco, tipoDePublico);
        }

        private static void Validar(string nome, string cpf, string telefone, Endereco endereco, string tipoDePublico)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(cpf), "CPF é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(telefone), "Telefone é obrigatório");
            ExcecaoDeDominio.Quando(endereco == null, "Endereço é obrigatório");
            ExcecaoDeDominio.Quando(tipoDePublico == null, "Tipo de publico é obrigatório");
        }

        private void Atribuir(string nome, string cpf, string telefone, Endereco endereco, string tipoDePublico)
        {
            Nome = nome;
            Cpf = cpf;
            Telefone = telefone;
            Endereco = endereco;
            TipoDePublico = tipoDePublico;
        }
    }
}