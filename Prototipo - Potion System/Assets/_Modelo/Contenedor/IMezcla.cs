namespace ItIsNotOnlyMe
{
    public interface IMezcla
    {
        public void Agregar(IIngrediente ingrediente);

        public void Mezclar();

        public Atributos CalcularEstado();

        public void Finalizar();
    }
}
