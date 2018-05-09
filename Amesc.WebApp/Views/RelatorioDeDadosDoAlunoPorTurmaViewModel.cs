using Amesc.Dominio.Pessoas;

namespace Amesc.WebApp.Views
{
    public class RelatorioDeDadosDoAlunoPorTurmaViewModel
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string TipoDePublico { get; set; }
        public string Telefone { get; set; }
        public string OrgaoEmissor { get; set; }
        public string RG { get; set; }
        public string DataDeNascimento { get; set; }
        public string RegistroProfissional { get; set; }
        public string Especialidade { get; set; }

        public RelatorioDeDadosDoAlunoPorTurmaViewModel(Pessoa pessoa)
        {
            Nome = pessoa.Nome;
            Cpf = pessoa.Cpf;
            if(pessoa.Endereco != null)
                Endereco = $"{pessoa.Endereco.Logradouro}, {pessoa.Endereco.Numero}, {pessoa.Endereco.Bairro}, {pessoa.Endereco.Cidade}";
            TipoDePublico = pessoa.TipoDePublico;
            Telefone = pessoa.Telefone;
            OrgaoEmissor = pessoa.OrgaoEmissorDoRg;
            RG = pessoa.Rg;
            DataDeNascimento = pessoa.DataDeNascimento.ToString("dd/MM/yyyy");
            RegistroProfissional = pessoa.RegistroProfissional;
            Especialidade = pessoa.Especialidade;
        }
    }
}