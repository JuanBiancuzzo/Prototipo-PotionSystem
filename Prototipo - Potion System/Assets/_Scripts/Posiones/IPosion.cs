namespace ItIsNotOnlyMe
{
    public interface IPosion
    { 
        public Atributos GetAtributos();

        public float Distancia(IPosion posion);

        public float Similitud(IPosion posion);

        public float Multiplicidad(IPosion posion);
    }
}
