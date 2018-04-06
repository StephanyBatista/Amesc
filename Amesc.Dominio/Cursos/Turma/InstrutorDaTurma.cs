using Amesc.Dominio.Cursos.Instrutores;

namespace Amesc.Dominio.Cursos.Turma
{
    public class InstrutorDaTurma : Entidade
    {
        public InstrutorDaTurma() { }

        public InstrutorDaTurma(Instrutor instrutor, CargoNaTurma cargo)
        {
            Instrutor = instrutor;
            Cargo = cargo;
        }

        public Instrutor Instrutor { get; set; }
        public CargoNaTurma Cargo { get; set; }
    }
}