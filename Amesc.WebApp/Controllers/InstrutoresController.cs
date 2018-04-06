using System.Linq;
using Amesc.Dominio.Cursos.Instrutores;
using Amesc.WebApp.Util;
using Microsoft.AspNetCore.Mvc;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Amesc.WebApp.Controllers
{
    [Authorize]
    public class InstrutoresController : Controller
    {
        private readonly ArmazenadorDeInstrutor _armazenadorDeInstrutor;
        private readonly IInstrutorRepositorio _isntrutorRepositorio;

        public InstrutoresController(
            ArmazenadorDeInstrutor armazenadorDeInstrutor, 
            IInstrutorRepositorio isntrutorRepositorio)
        {
            _armazenadorDeInstrutor = armazenadorDeInstrutor;
            _isntrutorRepositorio = isntrutorRepositorio;
        }

        public IActionResult Index()
        {
            var instrutores = !string.IsNullOrEmpty(Request.Query["q"]) ?
                _isntrutorRepositorio.ConsultarPorNome(Request.Query["q"]) :
                _isntrutorRepositorio.Consultar();

            var models = instrutores.Select(c => 
                new InstrutorParaListaViewModel
                {
                    Id = c.Id, Codigo = c.Codigo, Nome = c.Nome, Email = c.Email

                });

            return View(PaginatedList<InstrutorParaListaViewModel>.Create(models, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar", new InstrutorParaCadastroViewModel());
        }

        public IActionResult Editar(int id)
        {
            var instrutor = _isntrutorRepositorio.ObterPorId(id);

            if (instrutor == null)
                return RedirectToAction("Index");

            return View("NovoOuEditar", new InstrutorParaCadastroViewModel(instrutor));
        }

        [HttpPost]
        public IActionResult Salvar(InstrutorParaCadastroViewModel model)
        {
            _armazenadorDeInstrutor.Armazenar(
                model.Id, model.Codigo, model.Nome, model.Email);

            return RedirectToAction("Index");
        }
    }
}