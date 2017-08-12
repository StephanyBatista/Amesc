using System;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Cursos
{
    public enum TipoDeCursoAberto
    {
        Nenhum,
        Publico,
        Fechado
    }

    public class CursoAberto : Entidade
    {
        public Curso Curso { get; private set; }
        public decimal Preco { get; private set; }
        public DateTime? PeriodoInicialParaMatricula { get; private set; }
        public DateTime? PeriodoFinalParaMatricula { get; private set; }
        public DateTime InicioDoCurso { get; private set; }
        public DateTime FimDoCurso { get; private set; }
        public TipoDeCursoAberto Tipo { get; private set; }

        public CursoAberto() { }

        public CursoAberto(Curso curso, 
            decimal preco, TipoDeCursoAberto tipoDeCursoAberto, 
            DateTime? periodoInicialParaMatricula, 
            DateTime? periodoFinalParaMatricula, 
            DateTime inicioDoCurso, 
            DateTime fimDoCurso)
        {
            Validar(curso, preco, tipoDeCursoAberto, periodoInicialParaMatricula, periodoFinalParaMatricula, inicioDoCurso, fimDoCurso);
            Atribuir(curso, preco, tipoDeCursoAberto, periodoInicialParaMatricula, periodoFinalParaMatricula, inicioDoCurso, fimDoCurso);
        }

        public void Editar(Curso curso, 
            decimal preco, 
            TipoDeCursoAberto tipoDeCursoAberto, 
            DateTime? periodoInicialParaMatricula, 
            DateTime? periodoFinalParaMatricula, 
            DateTime inicioDoCurso, 
            DateTime fimDoCurso)
        {
            Validar(curso, preco, tipoDeCursoAberto, periodoInicialParaMatricula, periodoFinalParaMatricula, inicioDoCurso, fimDoCurso);
            Atribuir(curso, preco, tipoDeCursoAberto, periodoInicialParaMatricula, periodoFinalParaMatricula, inicioDoCurso, fimDoCurso);
        }

        private static void Validar(Curso curso, 
            decimal preco, 
            TipoDeCursoAberto tipoDeCursoAberto, 
            DateTime? periodoInicialParaMatricula, 
            DateTime? periodoFinalParaMatricula, 
            DateTime inicioDoCurso, 
            DateTime fimDoCurso)
        {
            ExcecaoDeDominio.Quando(curso == null, "Curso é obrigatório");
            ExcecaoDeDominio.Quando(preco <= 0, "Preço do curso inválido");
            ExcecaoDeDominio.Quando(tipoDeCursoAberto == TipoDeCursoAberto.Nenhum, "Tipo de curso aberto é obrigatório");
            ExcecaoDeDominio.Quando(tipoDeCursoAberto == TipoDeCursoAberto.Publico && !periodoInicialParaMatricula.HasValue, "Período inicial para matricula é obrigatório");
            ExcecaoDeDominio.Quando(tipoDeCursoAberto == TipoDeCursoAberto.Publico && !periodoFinalParaMatricula.HasValue, "Período final para matricula é obrigatório");
            ExcecaoDeDominio.Quando(periodoInicialParaMatricula > periodoFinalParaMatricula, "Período inicial é maior que período final para matricula");
            ExcecaoDeDominio.Quando(inicioDoCurso <= DateTime.MinValue, "Data de inicio do curso é obrigatório");
            ExcecaoDeDominio.Quando(inicioDoCurso < periodoFinalParaMatricula, "Data de inicio do curso menor que período final para matricula");
            ExcecaoDeDominio.Quando(fimDoCurso <= DateTime.MinValue, "Data de fim do curso é obrigatório");
            ExcecaoDeDominio.Quando(inicioDoCurso > fimDoCurso, "Data de inicio do curso maior que data de fim do curso");
        }

        private void Atribuir(Curso curso, 
            decimal preco, 
            TipoDeCursoAberto tipoDeCursoAberto, 
            DateTime? periodoInicialParaMatricula, 
            DateTime? periodoFinalParaMatricula, 
            DateTime inicioDoCurso, 
            DateTime fimDoCurso)
        {
            Curso = curso;
            Preco = preco;
            Tipo = tipoDeCursoAberto;
            PeriodoInicialParaMatricula = periodoInicialParaMatricula;
            PeriodoFinalParaMatricula = periodoFinalParaMatricula;
            InicioDoCurso = inicioDoCurso;
            FimDoCurso = fimDoCurso;
        }

        public virtual bool ContemPublicoAlvo(string publicoAlvo)
        {
            return Curso.ContemPublicoAlvo(publicoAlvo);
        }
    }
}

