namespace ItIsNotOnlyMe
{
    public interface IIngrediente : IDemandado, ICambiante
    {
        public Atributos Agregar(Atributos atributos);

        public IIngrediente Unirse(IIngrediente ingrediente);

        public bool PermiteUnirse();

        public bool PermiteUnirseCon(IIngrediente ingrediente);

        public void ModificarOtro(IIngrediente ingrediente);
    }
}