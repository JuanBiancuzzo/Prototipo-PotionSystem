namespace ItIsNotOnlyMe
{
    public interface IIngrediente : IDemandado, ICambiante
    {
        public Atributos Agregar(Atributos atributos);
    }
}