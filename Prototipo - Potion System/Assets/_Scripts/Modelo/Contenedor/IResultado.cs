using ItIsNotOnlyMe.VectorDinamico;

namespace ItIsNotOnlyMe.PotionSystem
{
    public interface IResultado
    { 
        public float Distancia(IResultado resultado);
        public float Distancia(Vector atributos);

        public float Similitud(IResultado resultado);
        public float Similitud(Vector atributos);

        public float Multiplicidad(IResultado resultado);
        public float Multiplicidad(Vector atributos);
    }
}
