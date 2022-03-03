namespace ItIsNotOnlyMe
{
    public interface IIngrediente : IDemandado, ICambiante
    {
        public Atributos Agregar(Atributos atributos);
        
        // si quiero hacerlo mas realista, puedo hacer que devuelva una lista
        // y de esa forma poder hacer que realmente el que permite unirse
        // sea el que se una y por lo tanto asi crear el compuesto
        public IIngrediente Unirse(IIngrediente ingrediente);

        public bool PermiteUnirse();

        public bool PermiteUnirseCon(IIngrediente ingrediente);

        public void ModificarOtro(IIngrediente ingrediente);
    }
}