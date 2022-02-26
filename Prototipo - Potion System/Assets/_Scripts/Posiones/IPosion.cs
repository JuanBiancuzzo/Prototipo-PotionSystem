namespace ItIsNotOnlyMe
{
    public interface IPosion
    { 
        public Propiedades GetPropiedades();

        public float Distancia(IPosion posion);

        public float Similitud(IPosion posion);

        public float Multiplicidad(IPosion posion);
    }
}
