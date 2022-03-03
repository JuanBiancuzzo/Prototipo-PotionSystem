namespace ItIsNotOnlyMe
{
    public interface IContenedor
    {
        public void AgregarIngrediente(IIngrediente ingrediente);

        public void Mezclar();

        public Posion Finalizar();
    }
}
