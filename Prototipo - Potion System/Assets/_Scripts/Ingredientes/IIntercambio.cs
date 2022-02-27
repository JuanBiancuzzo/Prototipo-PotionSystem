namespace ItIsNotOnlyMe
{
    public interface IIntercambio
    {
        public void Intercambiar(IIngrediente principal, IIngrediente otro);

        public IIntercambio CombinacionNueva(IIntercambio intercambio);
    }   
}