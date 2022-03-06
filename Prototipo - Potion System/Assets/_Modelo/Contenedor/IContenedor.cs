namespace ItIsNotOnlyMe
{
    public interface IContenedor
    {
        public void AgregarIngrediente(IIngrediente ingrediente);

        public void Mezclar(IIngrediente ingrediente1, IIngrediente ingrediente2);

        public Atributos CalcularEstado();

        public Pocion ConsumirPocion();
    }
}
