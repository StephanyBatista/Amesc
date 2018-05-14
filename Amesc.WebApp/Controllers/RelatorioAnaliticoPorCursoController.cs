using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.Dominio._Consultas;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Amesc.WebApp.Controllers
{
    public class RelatorioAnaliticoPorCursoController : Controller
    {
        private readonly IDadosAnaliticosPorCursoConsulta _dadosAnaliticosPorCursoConsulta;
        private readonly IRepositorio<Curso> _cursoRepositorio;

        public RelatorioAnaliticoPorCursoController(
            IDadosAnaliticosPorCursoConsulta dadosAnaliticosPorCursoConsulta,
            IRepositorio<Curso> cursoRepositorio)
        {
            _dadosAnaliticosPorCursoConsulta = dadosAnaliticosPorCursoConsulta;
            _cursoRepositorio = cursoRepositorio;
        }

        public async Task<IActionResult> Index(int? cursoId, int? ano)
        {
            var cursos = _cursoRepositorio.Consultar();
            ViewBag.Cursos = cursos.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Nome}",
                Selected = cursoId.HasValue && c.Id == cursoId.Value
            }).ToList();

            ViewBag.Anos = new List<int> { 2017, 2018, 2019, 2020 }.Select(c => new SelectListItem
            {
                Value = c.ToString(),
                Text = c.ToString(),
                Selected = ano == c
            }).ToList();

            if (!cursoId.HasValue)
                return View(null);

            var consulta = await _dadosAnaliticosPorCursoConsulta.Consultar(cursoId.Value, ano.Value);
            return View(consulta);
        }
    }
}