using System.Linq;
using Amesc.Dominio;
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
            var cursos = _alunoRepositorio.Consultar();
            var cursosViewModel =
                cursos.Select(c => new AlunoParaListaViewModel {Id = c.Id, Nome = c.Nome, Cpf = c.Cpf, TipoDePublico = c.TipoDePublico}).ToList();

            return View(cursosViewModel);
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

            return View("NovoOuEditar", 
                new AlunoParaCadastroViewModel
                {
                    Id = aluno.Id,
                    Nome = aluno.Nome,
                    Cpf = aluno.Cpf,
                    Telefone = aluno.Contato.Telefone,
                    Endereco = aluno.Contato.Endereco,
                    TipoDePublico = aluno.TipoDePublico
                });
        }

        [HttpPost]
        public IActionResult Salvar(AlunoParaCadastroViewModel model)
        {
            _armazenadorDeAluno.Armazenar(
                model.Id, model.Nome, model.Cpf, model.Telefone, model.Endereco, model.TipoDePublico);

            return RedirectToAction("Index");
        }
    }
}