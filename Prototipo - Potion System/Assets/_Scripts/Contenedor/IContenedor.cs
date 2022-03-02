namespace ItIsNotOnlyMe
{
    public interface IContenedor
    {
        public Posion Finalizar();

        public void AgregarIngrediente(IIngrediente ingrediente);

        //public void Avanzar(float dt);
    }
}
