namespace ItIsNotOnlyMe
{
    public interface IContenedor
    {
        public void AgregarIngrediente(IElemento elemento);

        public void Mezclar(IElemento elemento1, IElemento elemento2);

        public Atributos CalcularEstado();

        public Pocion ConsumirPocion();
    }
}
