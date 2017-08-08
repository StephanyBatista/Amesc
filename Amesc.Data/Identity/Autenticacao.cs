using Amesc.Dominio.Contas;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Amesc.Data.Identity
{
    public class Autenticacao : IAutenticacao
    {
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Autenticacao(SignInManager<ApplicationUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<bool> Autenticar(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Deslogar()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
