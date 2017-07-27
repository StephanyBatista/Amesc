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

        public void Armazenar(int id, string nome, string cpf, string telefone, string endereco, string publicoAlvo)
        {
            if (id == 0)
            {
                var aluno = new Aluno(nome, cpf, telefone, endereco, publicoAlvo);
                _alunoRepositorio.Adicionar(aluno);
            }
            else
            {
                var aluno = _alunoRepositorio.ObterPorId(id);
                aluno.Editar(nome, cpf, telefone, endereco, publicoAlvo);
            }
        }
    }
}