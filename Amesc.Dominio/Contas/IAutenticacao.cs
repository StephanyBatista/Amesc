using System.Threading.Tasks;

namespace Amesc.Dominio.Contas
{
    public interface IAutenticacao
    {
        Task<bool> Autenticar(string email, string password);
        Task Deslogar();
    }
}
