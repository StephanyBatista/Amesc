using System.Linq;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Amesc.WebApp.Controllers
{
    public class MatriculasController : Controller
    {
        private readonly CriacaoDeMatricula _criacaoDeMatricula;
        private readonly AlteracaoDeDadosDaMatricula _alteracaoDeDadosDaMatricula;
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;
        private readonly IAlunoRepositorio _alunoRepositorio;
        private readonly IMatriculaRepositorio _matriculaRepositorio;

        public MatriculasController(
            CriacaoDeMatricula criacaoDeMatricula, 
            AlteracaoDeDadosDaMatricula alteracaoDeDadosDaMatricula,
            ICursoAbertoRepositorio cursoAbertoRepositorio, 
            IAlunoRepositorio alunoRepositorio, IMatriculaRepositorio matriculaRepositorio)
        {
            _criacaoDeMatricula = criacaoDeMatricula;
            _alteracaoDeDadosDaMatricula = alteracaoDeDadosDaMatricula;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _alunoRepositorio = alunoRepositorio;
            _matriculaRepositorio = matriculaRepositorio;
        }

        public IActionResult Index()
        {
            var matriculas = _matriculaRepositorio.Consultar();
            var matriculasViewModel = matriculas.Select(m => new MatriculaParaListaViewModel(m)).ToList();

            return View(matriculasViewModel);
        }

        public IActionResult Novo()
        {
            var alunos = _alunoRepositorio.Consultar();
            var alunosViewModel = alunos.Select(a => new AlunoParaCadastroViewModel(a)).ToList();

            var cursoAbertos = _cursoAbertoRepositorio.Consultar();
            var cursosAbertosViewModel = cursoAbertos.Select(c => new CursoAbertoParaCadastroViewModel(c)).ToList();

            var model = new MatriculaParaCadastroViewModel
            {
                Alunos = alunosViewModel.OrderBy(a => a.Nome),
                CursosAbertos = cursosAbertosViewModel.OrderBy(c => c.NomeCurso)
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Novo(MatriculaParaCadastroViewModel model)
        {
            _criacaoDeMatricula.Criar(model.IdCursoAberto, model.IdAluno, model.EstaPago);

            return Ok();
        }

        public IActionResult Gerenciar(int id)
        {
            var matricula = _matriculaRepositorio.ObterPorId(id);
            var viewModel = new GerenciarMatriculaViewModel(matricula);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Gerenciar(GerenciarMatriculaViewModel model)
        {
            _alteracaoDeDadosDaMatricula.Alterar(model.Id, model.Observacao, model.NotaDoAlunoNoCurso);
            return Ok();
        }
    }
}