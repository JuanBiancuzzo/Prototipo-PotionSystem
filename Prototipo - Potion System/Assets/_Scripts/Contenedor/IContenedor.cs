namespace ItIsNotOnlyMe
{
    public interface IContenedor
    {
        public Posion Finalizar();

        public void ModificarMezcla(IIngrediente ingrediente);

        public void ModificarContenedor(IIngrediente ingrediente);
    }
}
