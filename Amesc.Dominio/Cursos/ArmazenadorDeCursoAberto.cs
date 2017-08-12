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

        public void Armazenar(
            int id, 
            int idCurso, 
            string precoEmString, 
            string tipoDeCursoAbertoEmString,
            string empresa,
            DateTime? periodoInicialParaMatricula, 
            DateTime? periodoFinalParaMatricula, 
            DateTime dataDeInicioDoCurso,
            DateTime dataDeFimDoCurso)
        {
            var curso = _cursoRepositorio.ObterPorId(idCurso);
            ExcecaoDeDominio.Quando(!decimal.TryParse(precoEmString, out decimal preco), "Preço inválido");
            ExcecaoDeDominio.Quando(!Enum.TryParse(tipoDeCursoAbertoEmString, out TipoDeCursoAberto tipo), "Tipo de curso inválido");

            CursoAberto cursoAberto = null;
            if (id > 0)
            {
                cursoAberto = _cursoAbertoRepositorio.ObterPorId(id);
                cursoAberto.Editar(
                    curso, 
                    preco,
                    tipo, 
                    empresa,
                    periodoInicialParaMatricula, 
                    periodoFinalParaMatricula, 
                    dataDeInicioDoCurso,
                    dataDeFimDoCurso);
            }
            else
            {
                cursoAberto = new CursoAberto(
                    curso, 
                    preco,
                    tipo,
                    empresa,
                    periodoInicialParaMatricula, 
                    periodoFinalParaMatricula, 
                    dataDeInicioDoCurso,
                    dataDeFimDoCurso);

                _cursoAbertoRepositorio.Adicionar(cursoAberto);
            }
        }
    }
}