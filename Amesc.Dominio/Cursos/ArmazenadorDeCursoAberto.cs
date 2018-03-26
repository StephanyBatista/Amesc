using System;
using Amesc.Dominio.Cursos.Instrutores;
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

        public void Armazenar(CursoAbertoParaCadastroViewModel model)
        {
            var curso = _cursoRepositorio.ObterPorId(model.IdCurso);
            ExcecaoDeDominio.Quando(!decimal.TryParse(model.Preco, out decimal preco), "Preço inválido");
            ExcecaoDeDominio.Quando(!Enum.TryParse(model.TipoDeCursoAberto, out TipoDeCursoAberto tipo), "Tipo de curso inválido");

            CursoAberto cursoAberto = null;
            if (model.Id > 0)
            {
                cursoAberto = _cursoAbertoRepositorio.ObterPorId(model.Id);
                cursoAberto.Editar(
                    model.Codigo,
                    curso, 
                    preco,
                    tipo,
                    model.Empresa,
                    model.PeriodoInicialParaMatricula,
                    model.PeriodoFinalParaMatricula,
                    model.InicioDoCurso,
                    model.FimDoCurso);
            }
            else
            {
                cursoAberto = new CursoAberto(
                    model.Codigo,
                    curso, 
                    preco,
                    tipo,
                    model.Empresa,
                    model.PeriodoInicialParaMatricula,
                    model.PeriodoFinalParaMatricula,
                    model.InicioDoCurso,
                    model.FimDoCurso);

                _cursoAbertoRepositorio.Adicionar(cursoAberto);
            }
        }
    }
}