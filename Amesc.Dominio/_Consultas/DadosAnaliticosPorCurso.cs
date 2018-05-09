using System.Collections.Generic;

namespace Amesc.Dominio._Consultas
{
    public class DadosAnaliticosPorCurso
    {
        public AprovacaoPorCurso AprovacaoPorCurso { get; set; }
        public List<CidadesDosAlunosPorCurso> CidadesDosAlunosPorCursos { get; set; }
        public List<PublicoAlvoPorCurso> PublicoAlvoPorCursos { get; set; }
    }
}
