namespace ItIsNotOnlyMe
{
    public interface IIngrediente : IDemandado, ICambiante, IVinculado
    {
        public Atributos Agregar(Atributos atributos);

        public void Estabilidad();

        public bool HayVinculo(IIngrediente ingrediente);

        public ICondicionDeVinculo EncontrarCondicion(IIngrediente ingrediente);

        public static bool Unirse(IIngrediente ingrediente1, IIngrediente ingrediente2)
        {
            if (ingrediente1.HayVinculo(ingrediente2) || ingrediente2.HayVinculo(ingrediente1))
                return false;

            ingrediente1.Estabilidad();
            ingrediente2.Estabilidad();

            IVinculo vinculo;
            ICondicionDeVinculo condicion;

            if (ingrediente1.PermiteVinculoCon(ingrediente2))
            {
                condicion = ingrediente1.EncontrarCondicion(ingrediente2);
                vinculo = new Vinculo(ingrediente1, ingrediente2, condicion);
            }
            else if (ingrediente2.PermiteVinculoCon(ingrediente1))
            {
                condicion = ingrediente2.EncontrarCondicion(ingrediente1);
                vinculo = new Vinculo(ingrediente2, ingrediente1, condicion);
            }
            else
            {
                return false;
            }

            ingrediente1.CrearVinculo(vinculo);
            ingrediente2.CrearVinculo(vinculo);

            return true;
        }
    }
}