using System.Linq;
using Amesc.Dominio.Pessoas;
using Amesc.WebApp.Util;
using Microsoft.AspNetCore.Mvc;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace Amesc.WebApp.Controllers
{
    [Authorize]
    public class InstrutoresController : Controller
    {
        private readonly ArmazenadorDePessoa _armazenadorDePessoa;
        private readonly IPessoaRepositorio _pessoaRepositorio;

        public InstrutoresController(ArmazenadorDePessoa armazenadorDePessoa, IPessoaRepositorio pessoaRepositorio)
        {
            _armazenadorDePessoa = armazenadorDePessoa;
            _pessoaRepositorio = pessoaRepositorio;
        }

        public IActionResult Index()
        {
            var pessoas = !string.IsNullOrEmpty(Request.Query["q"]) ?
                _pessoaRepositorio.ConsultarPorNome(Request.Query["q"]) :
                _pessoaRepositorio.Consultar();

            var alunosViewModel = pessoas.Where(a => a.TipoDePessoa == TipoDePessoa.Instrutor).Select(c => new PessoaParaListaViewModel(c));
            return View(PaginatedList<PessoaParaListaViewModel>.Create(alunosViewModel, Request));
        }

        public IActionResult Novo()
        {
            return View("NovoOuEditar");
        }

        public IActionResult Editar(int id)
        {
            var pessoa = _pessoaRepositorio.ObterPorId(id);

            if (pessoa == null)
                return RedirectToAction("Index");

            return View("NovoOuEditar", new PessoaParaCadastroViewModel(pessoa));
        }

        [HttpPost]
        public IActionResult Salvar(PessoaParaCadastroViewModel model)
        {
            _armazenadorDePessoa.Armazenar(
                model.Id,
                model.Nome,
                model.Cpf,
                model.OrgaoEmissorDoRg,
                model.Rg,
                model.DataDeNascimento,
                model.RegistroProfissional,
                model.Telefone,
                model.Numero,
                model.Logradouro,
                model.Cep,
                model.Bairro,
                model.Complemento,
                model.Cidade,
                model.Estado,
                model.TipoDePublico,
                model.Especialidade,
                model.MidiaSocial,
                TipoDePessoa.Instrutor);

            return Ok();
        }
    }
}