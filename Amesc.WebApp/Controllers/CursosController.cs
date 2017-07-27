using System.Linq;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Microsoft.AspNetCore.Mvc;
using Amesc.WebApp.ViewModels;

namespace Amesc.WebApp.Controllers
{
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
            var cursosViewModel =
                cursos.Select(c => new CursoParaListaViewModel {Id = c.Id, Nome = c.Nome, Descricao = c.Descricao}).ToList();

            return View(cursosViewModel);
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

            return View("NovoOuEditar", 
                new CursoParaCadastroViewModel
                {
                    Id = curso.Id,
                    Nome = curso.Nome,
                    Descricao = curso.Descricao,
                    Requisitos = curso.Requisitos,
                    PeriodoValidoEmAno = curso.PeriodoValidoEmAno,
                    PrecoSugerido = curso.PrecoSugerido.ToString(),
                    PublicosAlvo = curso.PublicosAlvo?.Select(publico => publico.Nome).ToList()
                });
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