using System.Collections.Generic;
using System.Linq;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Cursos.Instrutores;
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
        private readonly IInstrutorRepositorio _instrutorRepositorio;

        public AbrirCursoController(
            ArmazenadorDeCursoAberto armazenadorDeCursoAberto,
            ICursoAbertoRepositorio cursoAbertoRepositorio,
            IRepositorio<Curso> cursoRepositorio, 
            IInstrutorRepositorio instrutorRepositorio)
        {
            _armazenadorDeCursoAberto = armazenadorDeCursoAberto;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _cursoRepositorio = cursoRepositorio;
            _instrutorRepositorio = instrutorRepositorio;
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
            ViewBag.Curso = new CursoViewModel(curso);
            BuscarInstrutoresEDeclararNaViewBag();
        }

        private void BuscarInstrutoresEDeclararNaViewBag()
        {
            var instrutores = _instrutorRepositorio.Consultar();

            if (!instrutores.Any())
            {
                ViewBag.Instrutores = new List<InstrutorParaListaViewModel>();
                return;
            }

            var instrutoresParaLista =
                instrutores.Select(i => new InstrutorParaListaViewModel {Id = i.Id, Nome = i.Nome}).ToList();
            ViewBag.Instrutores = instrutoresParaLista;
        }

        [Route("AbrirCurso/Novo/{idCurso}")]
        public IActionResult Novo(int idCurso)
        {
            BuscarCursoEDeclararNaViewBag(idCurso);
            return View("NovoOuEditar", new CursoAbertoParaCadastroViewModel());
        }

        [Route("AbrirCurso/Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var cursoAberto = _cursoAbertoRepositorio.ObterPorId(id);

            if (cursoAberto == null)
                return RedirectToAction("Index");
            ViewBag.Curso = new CursoViewModel(cursoAberto.Curso);
            BuscarInstrutoresEDeclararNaViewBag();

            return View("NovoOuEditar", new CursoAbertoParaCadastroViewModel(cursoAberto));
        }

        [Route("AbrirCurso")]
        [HttpPost]
        public IActionResult Salvar(CursoAbertoParaCadastroViewModel model)
        {
            model.RemoverInstrutoresEmBranco();

            _armazenadorDeCursoAberto.Armazenar(model);

            return RedirectToAction("Index", new {idCurso = model.IdCurso});
        }
    }
}