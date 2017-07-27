namespace Amesc.Dominio.Cursos
{
    public class PublicoAlvoParaCurso : Entidade
    {
        public string Nome { get; private set; }

        public PublicoAlvoParaCurso() { }

        public PublicoAlvoParaCurso(string nome)
        {
            Nome = nome;
        }
    }
}
