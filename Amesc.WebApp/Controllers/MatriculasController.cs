using System.Linq;
using Amesc.Dominio.Alunos;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Matriculas;
using Amesc.WebApp.Util;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Amesc.WebApp.Controllers
{
    [Authorize]
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
            var somenteMatriculasPagas = string.IsNullOrEmpty(Request.Query["naopago"]);
            var validadeDoCursoExpirada = !string.IsNullOrEmpty(Request.Query["expirado"]);
            
            var matriculas = _matriculaRepositorio
                .ConsultarPor(
                    Request.Query["aluno"], 
                    Request.Query["curso"], 
                    somenteMatriculasPagas, 
                    validadeDoCursoExpirada);

            var models = matriculas.Select(m => new MatriculaParaListaViewModel(m));

            return View(PaginatedList<MatriculaParaListaViewModel>.Create(models, Request));
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
            _criacaoDeMatricula.Criar(model.IdCursoAberto, model.IdAluno, model.EstaPago, model.ValorPago);

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
            _alteracaoDeDadosDaMatricula.Alterar(model.Id, model.Observacao, model.NotaDoAlunoNoCurso, model.StatusDaAprovacao, model.Ip);
            return Ok();
        }
    }
}