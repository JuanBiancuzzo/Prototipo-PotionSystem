namespace ItIsNotOnlyMe
{
    public interface ICambiar 
    {
        public void Cambiar(ICambiante cambiante);

        public Vector Modificar(Vector atributos);
    }   

    public interface ICambiante
    {
        public void AgregarModificador(ICambiar modificador);

        public void SacarModificador(ICambiar modificador);
    }
}