namespace ItIsNotOnlyMe
{
    public class Contenedor : IContenedor
    {
        private Mezcla _mezcla;

        public void ModificarContenedor(IIngrediente ingrediente)
        {
            throw new System.NotImplementedException();
        }

        public void ModificarMezcla(IIngrediente ingrediente)
        {
            _mezcla.Agregar(ingrediente);
        }
        public Posion Finalizar()
        {
            return _mezcla.Finalizar();
        }
    }
}
