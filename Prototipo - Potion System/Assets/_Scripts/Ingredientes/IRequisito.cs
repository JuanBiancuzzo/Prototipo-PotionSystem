namespace ItIsNotOnlyMe
{
    public interface IRequisito
    {
        //public int GetID();

        public float ConseguirValor(IIngrediente ingrediente, IIdentificador identid);

        public bool Evaluar(IIngrediente ingrediente);

        //public bool Permitido(IIngrediente principal, IIngrediente otro);

        //public IRequisito CombinacionNueva(IRequisito requisito);
    }
}