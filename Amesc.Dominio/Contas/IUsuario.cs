namespace Amesc.Dominio.Contas
{
    public interface IUsuario
    {
        string Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
    }
}
