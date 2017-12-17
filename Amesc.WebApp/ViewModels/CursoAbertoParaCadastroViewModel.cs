using System;
using System.ComponentModel.DataAnnotations;
using Amesc.Dominio.Cursos;

namespace Amesc.WebApp.ViewModels
{
    public class CursoAbertoParaCadastroViewModel
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public int IdCurso { get; set; }
        public string NomeCurso { get; set; }
        public string NomeCursoEDataDoCurso => $"{NomeCurso} - {InicioDoCurso:dd/MM/yyyy}";
        public string TipoDeCursoAberto { get; set; }
        public string Empresa { get; set; }
        [Required(ErrorMessage = "Data de abertura é obrigatório")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Data de abertura inválida")]
        public DateTime? PeriodoInicialParaMatricula { get; set; }
        [Required(ErrorMessage = "Data de fechamento é obrigatório")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Data de fechamento inválida")]
        public DateTime? PeriodoFinalParaMatricula { get; set; }
        [Required(ErrorMessage = "Data de inicio do curso é obrigatório")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Data do curso inválido")]
        public DateTime InicioDoCurso { get; set; }
        [Required(ErrorMessage = "Data de fim do curso é obrigatório")]
        [RegularExpression(@"^(?:(?:31(\/|-|\.)(?:0?[13578]|1[02]))\1|(?:(?:29|30)(\/|-|\.)(?:0?[1,3-9]|1[0-2])\2))(?:(?:1[6-9]|[2-9]\d)?\d{2})$|^(?:29(\/|-|\.)0?2\3(?:(?:(?:1[6-9]|[2-9]\d)?(?:0[48]|[2468][048]|[13579][26])|(?:(?:16|[2468][048]|[3579][26])00))))$|^(?:0?[1-9]|1\d|2[0-8])(\/|-|\.)(?:(?:0?[1-9])|(?:1[0-2]))\4(?:(?:1[6-9]|[2-9]\d)?\d{2})$", ErrorMessage = "Data do curso inválido")]
        public DateTime FimDoCurso { set; get; }
        [Required(ErrorMessage = "Preço é obrigatório")]
        public string Preco { get; set; }

        public CursoAbertoParaCadastroViewModel() { }

        public CursoAbertoParaCadastroViewModel(CursoAberto entidade)
        {
            Id = entidade.Id;
            Codigo = entidade.Codigo;
            IdCurso = entidade.Curso.Id;
            NomeCurso = entidade.Curso.Nome;
            Preco = entidade.Preco.ToString();
            PeriodoInicialParaMatricula = entidade.PeriodoInicialParaMatricula;
            PeriodoFinalParaMatricula = entidade.PeriodoFinalParaMatricula;
            InicioDoCurso = entidade.InicioDoCurso.Date;
            FimDoCurso = entidade.FimDoCurso.Date;
            TipoDeCursoAberto = entidade.Tipo.ToString();
            Empresa = entidade.Empresa;
        }
    }
}