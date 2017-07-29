using System.Collections.Generic;
using System.Linq;
using Amesc.Dominio._Base;

namespace Amesc.Dominio.Cursos
{
    public class Curso : Entidade
    {
        public string Requisitos { get; private set; }
        public int? PeriodoValidoEmAno { get; private set; }
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal PrecoSugerido { get; private set; }
        public List<PublicoAlvoParaCurso> PublicosAlvo { get; private set; }

        private Curso() { }

        public Curso(string nome, string descricao, decimal precoSugerido, List<string> publicosAlvo, string requisitos, int? periodoValidoEmAno)
        {
            Validar(nome, descricao, requisitos);
            Atribuir(nome, descricao, precoSugerido, publicosAlvo, requisitos, periodoValidoEmAno);
        }

        public void Editar(string nome, string descricao, decimal precoSugerido, List<string> publicosAlvo, string requisitos, int? periodoValidoEmAno)
        {
            Validar(nome, descricao, requisitos);
            Atribuir(nome, descricao, precoSugerido, publicosAlvo, requisitos, periodoValidoEmAno);
        }

        private void Atribuir(string nome, string descricao, decimal precoSugerido, List<string> publicosAlvo, string requisitos, int? periodoValidoEmAno)
        {
            Nome = nome;
            Descricao = descricao;
            PrecoSugerido = precoSugerido;
            if(publicosAlvo != null)
                PublicosAlvo = publicosAlvo.Select(nomeDoPublicoAlvo => new PublicoAlvoParaCurso(nomeDoPublicoAlvo)).ToList();
            Requisitos = requisitos;
            PeriodoValidoEmAno = periodoValidoEmAno;
        }

        private static void Validar(string nome, string descricao, string requisitos)
        {
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(nome), "Nome é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(descricao), "Descrição é obrigatório");
            ExcecaoDeDominio.Quando(string.IsNullOrEmpty(requisitos), "Requisitos são obrigatórios");
        }

        public bool ContemPublicoAlvo(string publicoAlvo)
        {
            return PublicosAlvo.Exists(p => p.Nome == publicoAlvo);
        }
    }
}
