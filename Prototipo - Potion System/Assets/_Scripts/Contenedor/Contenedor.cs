namespace ItIsNotOnlyMe
{
    public class Contenedor : IContenedor
    {
        private Mezcla _mezcla;
        private Atributos _estado;

        public Contenedor(Mezcla mezcla, Atributos estadoInicial)
        {
            _mezcla = mezcla;
            _estado = estadoInicial;
        }

        public void AgregarIngrediente(IIngrediente ingrediente)
        {
            _mezcla.Agregar(ingrediente);
        }

        public void Avanzar(float dt)
        {
            _mezcla.Avanzar(dt);
            _estado = Atributos.Sumar(_estado, _mezcla.CalcularEstado());
        }

        public Posion Finalizar()
        {
            _mezcla.Finalizar();
            return new Posion(_estado);
        }
    }
}
