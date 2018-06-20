using System.Collections.Generic;

namespace Amesc.Dominio
{
    public interface IRepositorio<TEntidade>
    {
        List<TEntidade> Consultar();
        TEntidade ObterPorId(int id);
        void Adicionar(TEntidade entity);
    }
}
