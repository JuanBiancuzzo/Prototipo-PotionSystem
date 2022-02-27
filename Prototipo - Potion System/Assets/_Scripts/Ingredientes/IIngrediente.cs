namespace ItIsNotOnlyMe
{
    public interface IIngrediente
    {
        public Atributos Agregar(Atributos atributos);

        public float ObtenerValor(IIdentificador identificador);

        /*public IRequisito UnirReglas(IRequisito reglas);

        public IRequisito UnirReglas(IIngrediente ingrediente);

        public IIntercambio UnirGuias(IIntercambio guias);

        public IIntercambio UnirGuias(IIngrediente ingrediente);

        public bool PermiteUnirse(IIngrediente otro);

        public void AplicarIntercambio(IIngrediente otro);

        public IIngrediente CrearCombinacion(IIngrediente otro);*/
    }
}