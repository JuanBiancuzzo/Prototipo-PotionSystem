namespace ItIsNotOnlyMe
{
    public interface IResultado
    { 
        public float Distancia(IResultado resultado);
        public float Distancia(Atributos atributos);

        public float Similitud(IResultado resultado);
        public float Similitud(Atributos atributos);

        public float Multiplicidad(IResultado resultado);
        public float Multiplicidad(Atributos atributos);
    }
}
