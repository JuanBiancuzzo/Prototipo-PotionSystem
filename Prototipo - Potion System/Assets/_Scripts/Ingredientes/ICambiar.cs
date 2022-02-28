namespace ItIsNotOnlyMe
{
    public interface ICambiar 
    {
        public void Cambiar(ICambiante cambiante);

        public float Modificar(IIdentificador identificador, float valor);
    }   

    public interface ICambiante
    {
        public void AgregarModificador(ICambiar modificador);
    }
}