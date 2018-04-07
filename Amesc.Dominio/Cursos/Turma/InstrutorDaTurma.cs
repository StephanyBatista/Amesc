using Amesc.Dominio.Pessoas;

namespace Amesc.Dominio.Cursos.Turma
{
    public class InstrutorDaTurma : Entidade
    {
        public InstrutorDaTurma() { }

        public InstrutorDaTurma(Pessoa instrutor, CargoNaTurma cargo)
        {
            Instrutor = instrutor;
            Cargo = cargo;
        }

        public Pessoa Instrutor { get; set; }
        public CargoNaTurma Cargo { get; set; }
    }
}