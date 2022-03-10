namespace ItIsNotOnlyMe
{
    public interface IElemento : IDemandado, ICambiante, IVinculado
    {
        public Vector Agregar(Vector vector);

        public void Estabilidad();

        public bool HayVinculo(IElemento elemento);

        public ICondicionDeVinculo EncontrarCondicion(IElemento elemento);

        public static bool Unirse(IElemento elemento1, IElemento elemento2)
        {
            if (elemento1.HayVinculo(elemento2) || elemento2.HayVinculo(elemento1))
                return false;

            elemento1.Estabilidad();
            elemento2.Estabilidad();

            IVinculo vinculo;
            ICondicionDeVinculo condicion;

            if (elemento1.PermiteVinculoCon(elemento2))
            {
                condicion = elemento1.EncontrarCondicion(elemento2);
                vinculo = new Vinculo(elemento1, elemento2, condicion);
            }
            else if (elemento2.PermiteVinculoCon(elemento1))
            {
                condicion = elemento2.EncontrarCondicion(elemento1);
                vinculo = new Vinculo(elemento2, elemento1, condicion);
            }
            else
            {
                return false;
            }

            elemento1.CrearVinculo(vinculo);
            elemento2.CrearVinculo(vinculo);

            return true;
        }
    }
}