using System;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Cursos
{
    public class ArmazenadorDeCursoAberto
    {
        private readonly IRepositorio<Curso> _cursoRepositorio;
        private readonly IRepositorio<CursoAberto> _cursoAbertoRepositorio;

        public ArmazenadorDeCursoAberto(IRepositorio<Curso> cursoRepositorio, IRepositorio<CursoAberto> cursoAbertoRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
        }

        public void Armazenar(int id, int idCurso, string precoEmString, DateTime dataDeAbertura, DateTime dataDeFechamento, DateTime dataDoCurso)
        {
            var curso = _cursoRepositorio.ObterPorId(idCurso);
            ExcecaoDeDominio.Quando(!decimal.TryParse(precoEmString, out decimal preco), "Preço inválido");

            CursoAberto cursoAberto = null;
            if (id > 0)
            {
                cursoAberto = _cursoAbertoRepositorio.ObterPorId(id);
                cursoAberto.Editar(curso, preco, dataDeAbertura, dataDeFechamento, dataDoCurso);
            }
            else
            {
                cursoAberto = new CursoAberto(curso, preco, dataDeAbertura, dataDeFechamento, dataDoCurso);
                _cursoAbertoRepositorio.Adicionar(cursoAberto);
            }
        }
    }
}