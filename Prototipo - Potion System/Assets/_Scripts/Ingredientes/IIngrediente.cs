namespace ItIsNotOnlyMe
{
    public interface IIngrediente : IDemandado, ICambiante
    {
        public Atributos Agregar(Atributos atributos, float multiplicador = 1);

        public IIngrediente Unirse(IIngrediente ingrediente);

        public bool PermiteUnirse();

        public void ModificarOtro(IIngrediente ingrediente);
    }
}