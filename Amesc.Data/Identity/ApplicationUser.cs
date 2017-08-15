using Amesc.Dominio.Contas;
using Microsoft.AspNetCore.Identity;

namespace Amesc.Data.Identity
{
    public class ApplicationUser : IdentityUser, IUsuario
    {

    }
}
