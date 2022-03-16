using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.PotionSystem
{
    public interface ICambiar 
    {
        public void Cambiar(ICambiante cambiante);

        public Vector Modificar(Vector atributos);
    }   
}