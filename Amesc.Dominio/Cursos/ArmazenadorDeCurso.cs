using System.Collections.Generic;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Cursos
{
    public class ArmazenadorDeCurso
    {
        private readonly IRepositorio<Curso> _cursoRepositorio;

        public ArmazenadorDeCurso(IRepositorio<Curso> cursoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
        }

        public void Armazenar(string codigo, int id, string nome, string descricao, string precoSugeridoEmString, List<string> publicosAlvo, string requisitos, int? periodoValidoEmAno)
        {
            ExcecaoDeDominio.Quando(!decimal.TryParse(precoSugeridoEmString, out decimal precoSugerido), "Preço sugerido é inválido");

            var curso = _cursoRepositorio.ObterPorId(id);

            if (curso == null)
            {
                curso = new Curso(codigo, nome, descricao, precoSugerido, publicosAlvo, requisitos, periodoValidoEmAno);
                _cursoRepositorio.Adicionar(curso);
            }
            else
                curso.Editar(codigo, nome, descricao, precoSugerido, publicosAlvo, requisitos, periodoValidoEmAno);
        }
    }
}
