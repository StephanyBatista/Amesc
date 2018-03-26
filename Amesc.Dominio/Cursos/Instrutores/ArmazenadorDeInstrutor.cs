using Amesc.Dominio._Base;

namespace Amesc.Dominio.Cursos.Instrutores
{
    public class ArmazenadorDeInstrutor
    {
        private readonly IInstrutorRepositorio _instrutorRepositorio;

        public ArmazenadorDeInstrutor(IInstrutorRepositorio instrutorRepositorio)
        {
            _instrutorRepositorio = instrutorRepositorio;
        }

        public void Armazenar(int id, string codigo, string nome, string email)
        {
            if (id > 0)
            {
                var instrutor = _instrutorRepositorio.ObterPorId(id);

                ExcecaoDeDominio.Quando(instrutor == null, "Instrutor para edição não foi encontrado");

                instrutor.Editar(codigo, nome, email);
            }
            else
                _instrutorRepositorio.Adicionar(new Instrutor(codigo, nome, email));
        }
    }
}