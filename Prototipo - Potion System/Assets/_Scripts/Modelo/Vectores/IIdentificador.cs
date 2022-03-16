namespace ItIsNotOnlyMe.VectorDinamico
{
    public interface IIdentificador
    {
        public int GetID();

        public bool EsIgual(IIdentificador identificador);
    }
}
