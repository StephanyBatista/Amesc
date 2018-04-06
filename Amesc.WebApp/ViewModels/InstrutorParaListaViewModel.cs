using System.Collections;

namespace Amesc.WebApp.ViewModels
{
    public class InstrutorParaListaViewModel : IEnumerable
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }
    }
}
