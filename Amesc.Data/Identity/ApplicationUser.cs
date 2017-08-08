using Amesc.Dominio.Contas;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Amesc.Data.Identity
{
    public class ApplicationUser : IdentityUser, IUsuario
    {

    }
}
