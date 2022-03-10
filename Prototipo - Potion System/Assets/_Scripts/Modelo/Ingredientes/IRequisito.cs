namespace ItIsNotOnlyMe
{
    public interface IRequisito
    {
        public float ConseguirValor(IDemandado demandado, IIdentificador identificador);

        public bool Evaluar(IDemandado demandado);
    }
}