using System.Linq;
using Amesc.Dominio.Alunos;
using Microsoft.AspNetCore.Mvc;
using Amesc.WebApp.ViewModels;

namespace Amesc.WebApp.Controllers
{
    public class AlunosController : Controller
    {
        private readonly ArmazenadorDeAluno _armazenadorDeAluno;
        private readonly IAlunoRepositorio _alunoRepositorio;

        public AlunosController(ArmazenadorDeAluno armazenadorDeAluno, IAlunoRepositorio alunoRepositorio)
        {
            _armazenadorDeAluno = armazenadorDeAluno;
            _alunoRepositorio = alunoRepositorio;
        }

        public IActionResult Index()
        {
            var alunos = _alunoRepositorio.Consultar();
            var alunosViewModel = alunos.Select(c => new AlunoParaListaViewModel(c)).ToList();

            return View(alunosViewModel);
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar");
        }

        public IActionResult Editar(int id)
        {
            var aluno = _alunoRepositorio.ObterPorId(id);

            if (aluno == null)
                return RedirectToAction("Index");

            return View("NovoOuEditar", new AlunoParaCadastroViewModel(aluno));
        }

        [HttpPost]
        public IActionResult Salvar(AlunoParaCadastroViewModel model)
        {
            _armazenadorDeAluno.Armazenar(
                model.Id, model.Nome, model.Cpf, model.Telefone, model.Endereco, model.TipoDePublico);

            return Ok();
        }
    }
}