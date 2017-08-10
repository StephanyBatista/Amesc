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
        public DateTime DataDeAbertura { get; private set; }
        public DateTime DataDeFechamento { get; private set; }
        public DateTime DataDoCurso { get; private set; }
        public TipoDeCursoAberto Tipo { get; private set; }

        public CursoAberto() { }

        public CursoAberto(Curso curso, decimal preco, TipoDeCursoAberto tipoDeCursoAberto, DateTime dataDeAbertura, DateTime dataDeFechamento, DateTime dataDoCurso)
        {
            Validar(curso, preco, tipoDeCursoAberto, dataDeAbertura, dataDeFechamento, dataDoCurso);
            Atribuir(curso, preco, tipoDeCursoAberto, dataDeAbertura, dataDeFechamento, dataDoCurso);
        }

        public void Editar(Curso curso, decimal preco, TipoDeCursoAberto tipoDeCursoAberto, DateTime dataDeAbertura, DateTime dataDeFechamento, DateTime dataDoCurso)
        {
            Validar(curso, preco, tipoDeCursoAberto, dataDeAbertura, dataDeFechamento, dataDoCurso);
            Atribuir(curso, preco, tipoDeCursoAberto, dataDeAbertura, dataDeFechamento, dataDoCurso);
        }

        private static void Validar(Curso curso, decimal preco, TipoDeCursoAberto tipoDeCursoAberto, DateTime dataDeAbertura, DateTime dataDeFechamento, DateTime dataDoCurso)
        {
            ExcecaoDeDominio.Quando(curso == null, "Curso é obrigatório");
            ExcecaoDeDominio.Quando(preco <= 0, "Preço do curso inválido");
            ExcecaoDeDominio.Quando(tipoDeCursoAberto == TipoDeCursoAberto.Nenhum, "Tipo de curso aberto é obrigatório");
            ExcecaoDeDominio.Quando(dataDeAbertura <= DateTime.MinValue, "Data de abertura inválida");
            ExcecaoDeDominio.Quando(dataDeAbertura > dataDeFechamento, "Data de abertura maior que data de fechamento");
            ExcecaoDeDominio.Quando(dataDeFechamento <= DateTime.MinValue, "Data de fechamento inválido");
            ExcecaoDeDominio.Quando(dataDoCurso <= DateTime.MinValue, "Data do curso inválido");
            ExcecaoDeDominio.Quando(dataDoCurso < dataDeFechamento, "Data do curso menor que data de fechamento");
        }

        private void Atribuir(Curso curso, decimal preco, TipoDeCursoAberto tipoDeCursoAberto, DateTime dataDeAbertura, DateTime dataDeFechamento, DateTime dataDoCurso)
        {
            Curso = curso;
            Preco = preco;
            Tipo = tipoDeCursoAberto;
            DataDeAbertura = dataDeAbertura;
            DataDeFechamento = dataDeFechamento;
            DataDoCurso = dataDoCurso;
        }

        public bool ContemPublicoAlvo(string publicoAlvo)
        {
            return Curso.ContemPublicoAlvo(publicoAlvo);
        }
    }
}

