using Amesc.Dominio.Cursos;

namespace Amesc.Dominio.Alunos
{
    public class ArmazenadorDeAluno
    {
        private readonly IRepositorio<Aluno> _alunoRepositorio;

        public ArmazenadorDeAluno(IRepositorio<Aluno> alunoRepositorio)
        {
            _alunoRepositorio = alunoRepositorio;
        }

        public void Armazenar(int id, string nome, string cpf, string telefone, string numero, string logradouro, string bairro, object complemento, string cidade, string estado, string publicoAlvo)
        {
            if (id == 0)
            {
                var endereço = new Endereco(numero, logradouro, bairro, complemento, cidade, estado);
                var aluno = new Aluno(nome, cpf, telefone, endereço, publicoAlvo);
                _alunoRepositorio.Adicionar(aluno);
            }
            else
            {
                var endereço = new Endereco(numero, logradouro, bairro, complemento, cidade, estado);
                var aluno = _alunoRepositorio.ObterPorId(id);
                aluno.Editar(nome, cpf, telefone, endereço, publicoAlvo);
            }
        }
    }
}