using System.Linq;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.WebApp.Util;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Amesc.WebApp.Controllers
{
    [Authorize]
    public class AbrirCursoController : Controller
    {
        private readonly ArmazenadorDeCursoAberto _armazenadorDeCursoAberto;
        private readonly IRepositorio<Curso> _cursoRepositorio;
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;

        public AbrirCursoController(
            ArmazenadorDeCursoAberto armazenadorDeCursoAberto,
            ICursoAbertoRepositorio cursoAbertoRepositorio,
            IRepositorio<Curso> cursoRepositorio)
        {
            _armazenadorDeCursoAberto = armazenadorDeCursoAberto;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _cursoRepositorio = cursoRepositorio;
        }

        [Route("AbrirCurso/{idCurso}")]
        public IActionResult Index(int idCurso)
        {
            BuscarCursoEDeclararNaViewBag(idCurso);
            var cursosAbertos = _cursoAbertoRepositorio.ListarPorCurso(idCurso);
            var models = cursosAbertos.Select(m => new CursoAbertoParaListaViewModel(m));

            return View(PaginatedList<CursoAbertoParaListaViewModel>.Create(models, Request));
        }

        private void BuscarCursoEDeclararNaViewBag(int id)
        {
            var curso = _cursoRepositorio.ObterPorId(id);
            DeclararCursoNaViewBag(curso);
        }

        private void DeclararCursoNaViewBag(Curso curso)
        {
            if(curso != null)
                ViewBag.Curso = new CursoViewModel(curso);
        }

        [Route("AbrirCurso/Novo/{idCurso}")]
        public IActionResult Novo(int idCurso)
        {
            BuscarCursoEDeclararNaViewBag(idCurso);
            return View("NovoOuEditar");
        }

        [Route("AbrirCurso/Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var cursoAberto = _cursoAbertoRepositorio.ObterPorId(id);

            if (cursoAberto == null)
                return RedirectToAction("Index");

            DeclararCursoNaViewBag(cursoAberto.Curso);

            return View("NovoOuEditar", new CursoAbertoParaCadastroViewModel(cursoAberto));
        }

        [Route("AbrirCurso")]
        [HttpPost]
        public IActionResult Salvar(CursoAbertoParaCadastroViewModel model)
        {
            _armazenadorDeCursoAberto.Armazenar(model.Id, model.IdCurso, model.Preco, model.TipoDeCursoAberto, model.DataDeAbertura, model.DataDeFechamento, model.DataDoCurso);

            return RedirectToAction("Index", new {idCurso = model.IdCurso});
        }
    }
}