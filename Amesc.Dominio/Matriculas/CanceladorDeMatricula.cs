namespace Amesc.Dominio.Matriculas
{
    public class CanceladorDeMatricula
    {
        private readonly IMatriculaRepositorio _matriculaRepositorioObject;

        public CanceladorDeMatricula(IMatriculaRepositorio matriculaRepositorioObject)
        {
            _matriculaRepositorioObject = matriculaRepositorioObject;
        }

        public void Cancelar(int matriculaId)
        {
            var matricula = _matriculaRepositorioObject.ObterPorId(matriculaId);

            matricula.CancelarMatricula();
        }
    }
}