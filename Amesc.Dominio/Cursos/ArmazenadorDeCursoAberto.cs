using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using Amesc.Dominio.Cursos.Instrutores;
using Amesc.Dominio.Cursos.Turma;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Cursos
{
    public class ArmazenadorDeCursoAberto
    {
        private readonly IRepositorio<Curso> _cursoRepositorio;
        private readonly ICursoAbertoRepositorio _cursoAbertoRepositorio;
        private readonly IInstrutorRepositorio _instrutorRepositorio;

        public ArmazenadorDeCursoAberto(
            IRepositorio<Curso> cursoRepositorio,
            ICursoAbertoRepositorio cursoAbertoRepositorio, 
            IInstrutorRepositorio instrutorRepositorio)
        {
            _cursoRepositorio = cursoRepositorio;
            _cursoAbertoRepositorio = cursoAbertoRepositorio;
            _instrutorRepositorio = instrutorRepositorio;
        }

        public void Armazenar(CursoAbertoParaCadastroViewModel model)
        {
            var curso = _cursoRepositorio.ObterPorId(model.IdCurso);
            ExcecaoDeDominio.Quando(!decimal.TryParse(model.Preco, out decimal preco), "Preço inválido");
            ExcecaoDeDominio.Quando(!Enum.TryParse(model.TipoDeCursoAberto, out TipoDeCursoAberto tipo), "Tipo de curso inválido");

            var cursoAberto = new CursoAberto(
                model.Codigo,
                curso,
                preco,
                tipo,
                model.Empresa,
                model.PeriodoInicialParaMatricula,
                model.PeriodoFinalParaMatricula,
                model.InicioDoCurso,
                model.FimDoCurso);

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

            AdicionarOuRemoverInstrutor(model, cursoAberto);

            if(model.Id == 0)
                _cursoAbertoRepositorio.Adicionar(cursoAberto);
        }

        private void AdicionarOuRemoverInstrutor(CursoAbertoParaCadastroViewModel model, CursoAberto cursoAberto)
        {
            foreach (var instrutorDaTurmaViewModel in model.Instrutores)
            {
                var instrutor = _instrutorRepositorio.ObterPorId(instrutorDaTurmaViewModel.Id);
                Enum.TryParse<CargoNaTurma>(instrutorDaTurmaViewModel.Cargo, out var cargo);
                cursoAberto.AdicionarInstrutor(instrutor, cargo);
            }

            if (cursoAberto.Instrutores == null) return;

            var instrutoresDaTurmaParaRemover = new List<InstrutorDaTurma>();
            foreach (var instrutorDaTurma in cursoAberto.Instrutores)
            {
                if (!model.Instrutores.Exists(i => i.Id == instrutorDaTurma.Instrutor.Id && i.Cargo == instrutorDaTurma.Cargo.ToString()))
                    instrutoresDaTurmaParaRemover.Add(new InstrutorDaTurma(instrutorDaTurma.Instrutor, instrutorDaTurma.Cargo));
            }

            foreach (var instrutorDaTurma in instrutoresDaTurmaParaRemover)
            {
                cursoAberto.RemoverInstrutor(instrutorDaTurma.Instrutor, instrutorDaTurma.Cargo);
            }
        }
    }
}