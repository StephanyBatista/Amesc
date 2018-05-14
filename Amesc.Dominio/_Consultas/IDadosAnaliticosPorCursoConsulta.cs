using System.Threading.Tasks;

namespace Amesc.Dominio._Consultas
{
    public interface IDadosAnaliticosPorCursoConsulta
    {
        Task<DadosAnaliticosPorCurso> Consultar(int cursoId, int ano);
    }
}
