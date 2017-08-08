using Amesc.Dominio.Contas;
using Amesc.WebApp.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Amesc.WebApp.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacao _autenticacao;

        public AutenticacaoController(IAutenticacao authentication)
        {
            _autenticacao = authentication;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AutenticacaoViewModel model)
        {
            var result = await _autenticacao.Autenticar(model.Email, model.Password);

            if (result)
                return Redirect("/");
            else
            {
                ModelState.AddModelError(string.Empty, "E-mail ou senha estão invalidos");
                return View(model);
            }
        }

        public async Task<IActionResult> Deslogar()
        {
            await _autenticacao.Deslogar();
            return Redirect("/Autenticacao");
        }

        public IActionResult AccessoNegado()
        {
            return View();
        }
    }
}
