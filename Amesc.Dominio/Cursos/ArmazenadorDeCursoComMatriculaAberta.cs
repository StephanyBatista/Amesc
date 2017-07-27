using System;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Cursos
{
    public class ArmazenadorDeCursoComMatriculaAberta
    {
        private readonly IRepositorio<Curso> _cursoRepositorio;
        private readonly IRepositorio<CursoComMatriculaAberta> _cursoComMatriculaAbertaRepositorio;

        public ArmazenadorDeCursoComMatriculaAberta(IRepositorio<Curso> cursoRepositorio, IRepositorio<CursoComMatriculaAberta> cursoComMatriculaAbertaRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
            _cursoComMatriculaAbertaRepositorio = cursoComMatriculaAbertaRepositorio;
        }

        public void Armazenar(int id, int idCurso, string precoEmString, DateTime dataDeAbertura, DateTime dataDeFechamento, DateTime dataDoCurso)
        {
            var curso = _cursoRepositorio.ObterPorId(idCurso);
            ExcecaoDeDominio.Quando(!decimal.TryParse(precoEmString, out decimal preco), "Preço inválido");

            CursoComMatriculaAberta cursoComMatriculaAberta = null;
            if (id > 0)
            {
                cursoComMatriculaAberta = _cursoComMatriculaAbertaRepositorio.ObterPorId(id);
                cursoComMatriculaAberta.Editar(curso, preco, dataDeAbertura, dataDeFechamento, dataDoCurso);
            }
            else
            {
                cursoComMatriculaAberta = new CursoComMatriculaAberta(curso, preco, dataDeAbertura, dataDeFechamento, dataDoCurso);
                _cursoComMatriculaAbertaRepositorio.Adicionar(cursoComMatriculaAberta);
            }
        }
    }
}