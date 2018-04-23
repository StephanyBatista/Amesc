using System.Collections.Generic;
using System.Linq;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio.Matriculas;
using Amesc.WebApp.Views;
using Microsoft.AspNetCore.Mvc;

namespace Amesc.WebApp.Controllers
{
    public class RelatorioDeDadosDoAlunoPorTurmaController : Controller
    {
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;
        private readonly IMatriculaRepositorio _matriculaRepositorio;

        public RelatorioDeDadosDoAlunoPorTurmaController(ICursoAbertoRepositorio cursoAbertoRepositorio, IMatriculaRepositorio matriculaRepositorio)
        {
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _matriculaRepositorio = matriculaRepositorio;
        }

        public IActionResult Index(int? turmaId)
        {
            var cursoAbertos = _cursoAbertoRepositorio.Consultar();
            ViewBag.Turmas = cursoAbertos.Select(c => new CursoAbertoParaCadastroViewModel(c)).ToList();

            var alunos = new List<RelatorioDeDadosDoAlunoPorTurmaViewModel>();

            if (turmaId.HasValue)
            {
                var matriculas = _matriculaRepositorio.ConsultarTodosAlunosPor(turmaId.Value);
                alunos = matriculas.Select(m => new RelatorioDeDadosDoAlunoPorTurmaViewModel(m.Pessoa)).ToList();
            }

            return View(alunos);
        }
    }
}