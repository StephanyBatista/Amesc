using System.Collections.Immutable;
using System.Linq;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Amesc.WebApp.Controllers
{
    public class AbrirMatriculaController : Controller
    {
        private readonly ArmazenadorDeCursoComMatriculaAberta _armazenadorDeCursoComMatriculaAberta;
        private readonly IRepositorio<Curso> _cursoRepositorio;
        private readonly ICursoComMatriculaAbertaRepositorio _cursoComMatriculaAbertaRepositorio;

        public AbrirMatriculaController(
            ArmazenadorDeCursoComMatriculaAberta armazenadorDeCursoComMatriculaAberta,
            ICursoComMatriculaAbertaRepositorio cursoComMatriculaAbertaRepositorio,
            IRepositorio<Curso> cursoRepositorio)
        {
            _armazenadorDeCursoComMatriculaAberta = armazenadorDeCursoComMatriculaAberta;
            _cursoComMatriculaAbertaRepositorio = cursoComMatriculaAbertaRepositorio;
            _cursoRepositorio = cursoRepositorio;
        }

        [Route("AbrirMatricula/{idCurso}")]
        public IActionResult Index(int idCurso)
        {
            BuscarCursoEDeclararNaViewBag(idCurso);
            var matriculasAbertas = _cursoComMatriculaAbertaRepositorio.ListarPorCurso(idCurso);
            
            var models = matriculasAbertas.Select(m => new CursoComMatriculaAbertaParaListaViewModel
            {
                Id = m.Id,
                DataDeAbertura = m.DataDeAbertura.ToString("dd/MM/yyyy"),
                DataDeFechamento = m.DataDeFechamento.ToString("dd/MM/yyyy"),
                DataDoCurso = m.DataDoCurso.ToString("dd/MM/yyyy")
            }).ToList();
            return View(models);
        }

        private void BuscarCursoEDeclararNaViewBag(int id)
        {
            var curso = _cursoRepositorio.ObterPorId(id);
            DeclararCursoNaViewBag(curso);
        }

        private void DeclararCursoNaViewBag(Curso curso)
        {
            if(curso != null)
                ViewBag.Curso = new CursoViewModel {Id = curso.Id, Nome = curso.Nome};
        }

        [Route("AbrirMatricula/Novo/{idCurso}")]
        public IActionResult Novo(int idCurso)
        {
            BuscarCursoEDeclararNaViewBag(idCurso);
            return View("NovoOuEditar");
        }

        [Route("AbrirMatricula/Editar/{id}")]
        public IActionResult Editar(int id)
        {
            var cursoComMatriculaAberta = _cursoComMatriculaAbertaRepositorio.ObterPorId(id);

            if (cursoComMatriculaAberta == null)
                return RedirectToAction("Index");

            DeclararCursoNaViewBag(cursoComMatriculaAberta.Curso);

            return View("NovoOuEditar",
                new CursoComMatriculaAbertaParaCadastroViewModel
                {
                    Id = cursoComMatriculaAberta.Id,
                    IdCurso = cursoComMatriculaAberta.Curso.Id,
                    Preco = cursoComMatriculaAberta.Preco.ToString(),
                    DataDeAbertura = cursoComMatriculaAberta.DataDeAbertura.Date,
                    DataDeFechamento = cursoComMatriculaAberta.DataDeFechamento.Date,
                    DataDoCurso = cursoComMatriculaAberta.DataDoCurso.Date
                });
        }

        [Route("AbrirMatricula")]
        [HttpPost]
        public IActionResult Salvar(CursoComMatriculaAbertaParaCadastroViewModel model)
        {
            _armazenadorDeCursoComMatriculaAberta.Armazenar(model.Id, model.IdCurso, model.Preco, model.DataDeAbertura, model.DataDeFechamento, model.DataDoCurso);

            return RedirectToAction("Index", new {idCurso = model.IdCurso});
        }
    }
}