namespace ItIsNotOnlyMe
{
    public interface IContadorDeProgreso
    {
        public bool Finalizado();

        public void Avanzar(float dt);

        public float Porcentaje();

        public void Sumar(IContadorDeProgreso contadorDeProgreso);

        public void Restar(IContadorDeProgreso contadorDeProgreso);

        public IContadorDeProgreso Maximo();
    }
}
