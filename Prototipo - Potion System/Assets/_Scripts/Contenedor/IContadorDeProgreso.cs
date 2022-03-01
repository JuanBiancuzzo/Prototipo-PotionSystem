namespace ItIsNotOnlyMe
{
    public interface IContadorDeProgreso
    {
        public bool Finalizado();

        public void Avanzar(float dt);

        public float Porcentaje();
    }
}
