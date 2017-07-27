using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Http.Features;

namespace Amesc.WebApp.ViewModels
{
    public class CursoParaCadastroViewModel
    {
        public int Id { get; set; }
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

        public string ChecarPublicoAlvoParaInputHtml(string publico)
        {
            return PublicosAlvo != null && PublicosAlvo.Any() && PublicosAlvo.Contains(publico) ? "checked" : "";
        }
    }
}
