namespace ItIsNotOnlyMe
{
    public struct ProcesoIngrediente
    {
        private IIngrediente _ingrediente;
        private IContadorDeProgreso _contador;

        public ProcesoIngrediente(IIngrediente ingrediente, IContadorDeProgreso contador)
        {
            _ingrediente = ingrediente;
            _contador = contador;
        }

        public bool Finalizado()
        {
            return _contador.Finalizado();
        }

        public void Avanzar(float dt)
        {
            _contador.Avanzar(dt);
        }

        public float Porcentaje()
        {
            return _contador.Porcentaje();
        }

        public Atributos Agregar(Atributos atributos, float multiplicador = 1)
        {
            return _ingrediente.Agregar(atributos, multiplicador);
        }
    }
}
