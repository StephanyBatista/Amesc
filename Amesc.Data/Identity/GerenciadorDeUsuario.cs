using Amesc.Data.Contexts;
using Amesc.Dominio.Contas;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amesc.Data.Identity
{
    public class GerenciadorDeUsuario : IGerenciadorDeUsuario
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _dbContext;

        public GerenciadorDeUsuario(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<bool> Criar(string email, string password, string role)
        {
            var user = new ApplicationUser { UserName = email, Email = email };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, role);
                return true;
            }

            return false;
        }

        public List<IUsuario> ObterTodos()
        {

            var users = _dbContext.Users;

            return users.Any() ? users.Select(u => (IUsuario)u).ToList() : new List<IUsuario>();
        }
    }
}
