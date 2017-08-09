using System.Linq;
using System.Threading.Tasks;
using Amesc.Dominio.Alunos;
using Amesc.WebApp.Util;
using Microsoft.AspNetCore.Mvc;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Amesc.WebApp.Controllers
{
    [Authorize]
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
            var alunosViewModel = alunos.Select(c => new AlunoParaListaViewModel(c));
            return View(PaginatedList<AlunoParaListaViewModel>.Create(alunosViewModel, Request));
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