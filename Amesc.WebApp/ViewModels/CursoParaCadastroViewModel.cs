using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Amesc.Dominio.Cursos;

namespace Amesc.WebApp.ViewModels
{
    public class CursoParaCadastroViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        [Required(ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Descricao é obrigatório")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Descricao é obrigatório")]
        public string PrecoSugerido { get; set; }
        public List<string> PublicosAlvo { get; set; }
        [Required(ErrorMessage = "Requisitos é obrigatório")]
        public string Requisitos { get; set; }
        public int? PeriodoValidoEmAno { get; set; }

        public CursoParaCadastroViewModel() { }

        public CursoParaCadastroViewModel(Curso entidade)
        {
            Id = entidade.Id;
            Codigo = entidade.Codigo;
            Nome = entidade.Nome;
            Descricao = entidade.Descricao;
            Requisitos = entidade.Requisitos;
            PeriodoValidoEmAno = entidade.PeriodoValidoEmAno;
            PrecoSugerido = entidade.PrecoSugerido.ToString();
            PublicosAlvo = entidade.PublicosAlvo?.Select(publico => publico.Nome).ToList();
        }

        public string ChecarPublicoAlvoParaInputHtml(string publico)
        {
            return PublicosAlvo != null && PublicosAlvo.Any() && PublicosAlvo.Contains(publico) ? "checked" : "";
        }
    }
}
