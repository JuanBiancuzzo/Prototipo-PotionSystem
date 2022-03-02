namespace ItIsNotOnlyMe
{
    public class Contenedor : IContenedor
    {
        private Mezcla _mezcla;

        public Contenedor(Mezcla mezcla)
        {
            _mezcla = mezcla;
        }

        public void AgregarIngrediente(IIngrediente ingrediente)
        {
            _mezcla.Agregar(ingrediente);
        }

        public Posion Finalizar()
        {
            Atributos estado = _mezcla.CalcularEstado();
            _mezcla.Finalizar();
            return new Posion(estado);
        }
    }
}
