using System.Linq;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.WebApp.Util;
using Microsoft.AspNetCore.Mvc;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Amesc.WebApp.Controllers
{
    [Authorize]
    public class CursosController : Controller
    {
        private readonly ArmazenadorDeCurso _armazenadorDeCurso;
        private readonly IRepositorio<Curso> _cursoRepositorio;

        public CursosController(ArmazenadorDeCurso armazenadorDeCurso, IRepositorio<Curso> cursoRepositorio)
        {
            _armazenadorDeCurso = armazenadorDeCurso;
            _cursoRepositorio = cursoRepositorio;
        }

        public IActionResult Index()
        {
            var cursos = _cursoRepositorio.Consultar();
            var models = cursos.Select(c => new CursoParaListaViewModel {Id = c.Id, Nome = c.Nome, Descricao = c.Descricao});

            return View(PaginatedList<CursoParaListaViewModel>.Create(models, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new CursoParaCadastroViewModel());
        }

        public IActionResult Editar(int id)
        {
            var curso = _cursoRepositorio.ObterPorId(id);

            if (curso == null)
                return RedirectToAction("Index");

            return View("NovoOuEditar", new CursoParaCadastroViewModel(curso));
        }

        [HttpPost]
        public IActionResult Salvar(CursoParaCadastroViewModel model)
        {
            _armazenadorDeCurso.Armazenar(
                model.Id, model.Nome, model.Descricao, model.PrecoSugerido, model.PublicosAlvo, model.Requisitos, model.PeriodoValidoEmAno);

            return RedirectToAction("Index");
        }
    }
}