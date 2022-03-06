namespace ItIsNotOnlyMe
{
    public interface IPocion
    { 
        public Atributos GetAtributos();

        public float Distancia(IPocion posion);

        public float Similitud(IPocion posion);

        public float Multiplicidad(IPocion posion);
    }
}
