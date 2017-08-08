using System.Collections.Generic;
using System.Threading.Tasks;

namespace Amesc.Dominio.Contas
{
    public interface IGerenciadorDeUsuario
    {
        Task<bool> Criar(string email, string password, string role);
        List<IUsuario> ObterTodos();
    }
}
