using Amesc.Dominio.Alunos;

namespace Amesc.WebApp.ViewModels
{
    public class AlunoParaListaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string TipoDePublico { get; set; }

        public AlunoParaListaViewModel() { }

        public AlunoParaListaViewModel(Aluno entidade)
        {
            Id = entidade.Id;
            Nome = entidade.Nome;
            Cpf = entidade.Cpf;
            TipoDePublico = entidade.TipoDePublico;
        }
    }
}