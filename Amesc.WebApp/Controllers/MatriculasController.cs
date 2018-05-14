using System.Collections.Generic;
using System.Linq;
using Amesc.Dominio;
using Amesc.Dominio.Cursos;
using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio.Matriculas;
using Amesc.Dominio.Pessoas;
using Amesc.WebApp.Util;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Amesc.WebApp.Controllers
{
    [Authorize]
    public class MatriculasController : Controller
    {
        private readonly CriacaoDeMatricula _criacaoDeMatricula;
        private readonly AlteracaoDeDadosDaMatricula _alteracaoDeDadosDaMatricula;
        private readonly CanceladorDeMatricula _canceladorDeMatricula;
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IMatriculaRepositorio _matriculaRepositorio;
        private readonly IRepositorio<ComoFicouSabendo> _comoFicouSabendoRepositorio;

        public MatriculasController(
            CriacaoDeMatricula criacaoDeMatricula, 
            AlteracaoDeDadosDaMatricula alteracaoDeDadosDaMatricula,
            CanceladorDeMatricula canceladorDeMatricula,
            ICursoAbertoRepositorio cursoAbertoRepositorio, 
            IPessoaRepositorio pessoaRepositorio, IMatriculaRepositorio matriculaRepositorio, 
            IRepositorio<ComoFicouSabendo> comoFicouSabendoRepositorio)
        {
            _criacaoDeMatricula = criacaoDeMatricula;
            _alteracaoDeDadosDaMatricula = alteracaoDeDadosDaMatricula;
            _canceladorDeMatricula = canceladorDeMatricula;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _matriculaRepositorio = matriculaRepositorio;
            _comoFicouSabendoRepositorio = comoFicouSabendoRepositorio;
        }

        public IActionResult Index(string nomeDoAluno, int? turmaId, bool? cancelado, bool? pago, bool? expirado)
        {
            var cursoAbertos = _cursoAbertoRepositorio.Consultar();
            ViewBag.Turmas = cursoAbertos.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = $"{c.Curso.Nome} - {c.InicioDoCurso:dd/MM/yyyy}",
                Selected = turmaId.HasValue && c.Id == turmaId.Value
            }).ToList();

            ((List<SelectListItem>)ViewBag.Turmas).Insert(0, new SelectListItem { Value = "", Text = ""});

            var somenteCanceladas = cancelado.HasValue && cancelado.Value;
            var somenteMatriculasPagas = pago.HasValue && pago.Value;
            var validadeDoCursoExpirada = expirado.HasValue && expirado.Value;
            
            var matriculas = _matriculaRepositorio
                .ConsultarPor(
                    nomeDoAluno,
                    turmaId,
                    somenteCanceladas,
                    somenteMatriculasPagas, 
                    validadeDoCursoExpirada);

            var models = matriculas.Select(m => new MatriculaParaListaViewModel(m));

            return View(PaginatedList<MatriculaParaListaViewModel>.Create(models, Request));
        }

        public IActionResult Novo()
        {
            var alunos = _pessoaRepositorio.Consultar();
            var alunosViewModel = alunos.Select(a => new PessoaParaCadastroViewModel(a)).ToList();

            var cursoAbertos = _cursoAbertoRepositorio.Consultar();
            var cursosAbertosViewModel = cursoAbertos.Select(c => new CursoAbertoParaCadastroViewModel(c)).ToList();

            var comoFicouSabendo = _comoFicouSabendoRepositorio.Consultar();
            var comoFicouSabendoViewModel = comoFicouSabendo.OrderBy(i => i.Nome).Select(i => new InstrutorParaListaViewModel { Id = i.Id, Nome = i.Nome }).ToList();

            var model = new MatriculaParaCadastroViewModel
            {
                Alunos = alunosViewModel.OrderBy(a => a.Nome),
                CursosAbertos = cursosAbertosViewModel.OrderBy(c => c.NomeCurso),
                ComoFicouSabendo = comoFicouSabendoViewModel
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Novo(MatriculaParaCadastroViewModel model)
        {
            _criacaoDeMatricula.Criar(model.IdCursoAberto, model.IdAluno, model.EstaPago, model.ValorPago, model.IdComoFicouSabendo);

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

        public IActionResult CancelarMatricula(int id)
        {
            var matricula = _matriculaRepositorio.ObterPorId(id);
            var viewModel = new GerenciarMatriculaViewModel(matricula);

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Cancelar(int id)
        {
            _canceladorDeMatricula.Cancelar(id);
            return RedirectToAction("Gerenciar", new { id });
        }
    }
}