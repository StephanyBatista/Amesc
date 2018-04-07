using Amesc.Dominio.Pessoas;

namespace Amesc.WebApp.ViewModels
{
    public class PessoaParaListaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string TipoDePublico { get; set; }

        public PessoaParaListaViewModel() { }

        public PessoaParaListaViewModel(Pessoa entidade)
        {
            Id = entidade.Id;
            Nome = entidade.Nome;
            Cpf = entidade.Cpf;
            TipoDePublico = entidade.TipoDePublico;
        }
    }
}